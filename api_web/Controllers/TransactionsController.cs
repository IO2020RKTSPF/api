using System;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.DTOs;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Authorize]
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly IPodzielSieKsiazkaRepo _repo;
        private readonly IMapper _mapper;

        public TransactionsController(IPodzielSieKsiazkaRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult<TransactionReadDto> GetTransactionById(int id)
        {
            var transactionItem = _repo.GetTransactionById(id);
            if (transactionItem == null) return NotFound();
            return Ok(_mapper.Map<TransactionReadDto>(transactionItem));
        }
        [HttpPost]
        public ActionResult<TransactionReadDto> AddTransaction(TransactionAddDto transactionAddDto)
        {
            
            Book book = _repo.GetBookById(transactionAddDto.BookId);
            if (book == null)
                return NotFound();
            
            if (book.IsAvaible == false)
                return Forbid();
            var usrId = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            if (book.UserId == usrId)
                return Forbid();

            var transactionModel = _mapper.Map<Transaction>(transactionAddDto);

            transactionModel.DateTimeStart = DateTime.Now;
            transactionModel.DateTimeEnd = DateTime.Now.AddDays(transactionAddDto.DaysOfRentalTime);
            transactionModel.Status = TransactionStatus.Pending;
            transactionModel.RoomId = Guid.NewGuid().ToString();
            transactionModel.CustomerId = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            _repo.AddTransaction(transactionModel);
            book.IsAvaible = false;
            _repo.SaveChanges();
            
            var tReadDto = _mapper.Map<TransactionReadDto>(transactionModel);
            tReadDto.Customer = _repo.GetUserById(usrId);
            return Ok(tReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<TransactionReadDto> ChangeTransactionStatusById(TransactionChangeDto transactionChangeDto,int id)
        {
            Transaction transaction = _repo.GetTransactionById(id);
            
            if (transaction == null)
                return NotFound();

            if (transaction.Status == TransactionStatus.Finished || transaction.Status == TransactionStatus.Declined)
                return Forbid();

            Book book = _repo.GetBookById(transaction.BookId);

            if (Int32.Parse(User.Claims.First(p => p.Type == "id").Value) != book.UserId)
                return Forbid();

            transaction.Status = transactionChangeDto.Status;
            if (transaction.Status == TransactionStatus.Declined || transaction.Status == TransactionStatus.Finished)
                book.IsAvaible = true;
            _repo.SaveChanges();
            return Ok(_mapper.Map<TransactionReadDto>(transaction));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionReadDto>> GetAllTransactionsByUserId()
        {
            int id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var transactionItems = _repo.GetAllTransactionsByUserId(id).ToList();
            return Ok(_mapper.Map<IEnumerable<TransactionReadDto>>(transactionItems));
        }
    }
}
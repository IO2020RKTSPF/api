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
            if (Int32.Parse(User.Claims.First(p => p.Type == "id").Value) != book.Id)
                return Forbid();
            if (book.IsAvaible == false)
                return Forbid();
            
            var transactionModel = _mapper.Map<Transaction>(transactionAddDto);

            transactionModel.DateTimeStart = DateTime.Now;
            transactionModel.DateTimeEnd = DateTime.Now.AddDays(transactionAddDto.DaysOfRentalTime);
            _repo.AddTransaction(transactionModel);
            book.IsAvaible = false;
            _repo.SaveChanges();
            
            
            
            
            
            var tReadDto = _mapper.Map<TransactionReadDto>(transactionModel);

            return Ok(tReadDto);
        }
    }
}
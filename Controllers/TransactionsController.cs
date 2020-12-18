using api.Data;
using api.DTOs;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController
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
            if (transactionItem == null) return new NotFoundResult();
            return new OkObjectResult(_mapper.Map<TransactionReadDto>(transactionItem));
        }
    }
}
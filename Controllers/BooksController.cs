using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using api.Data;
using api.DTOs;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IPodzielSieKsiazkaRepo _repo;
        private readonly IMapper _mapper;

        public BooksController(IPodzielSieKsiazkaRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            var bookItems = _repo.GetAllBooks().ToList();
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(bookItems));
        }
        
        [HttpGet("{id}",Name ="GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var bookItem = _repo.GetBookById(id);
            if (bookItem == null) return NotFound();
            return Ok(_mapper.Map<BookReadDto>(bookItem));
        }
        [HttpPost]
        public ActionResult<BookReadDto> AddBook(BookAddDto bookAddDto)
        {
            var bookModel = _mapper.Map<Book>(bookAddDto);
            _repo.AddBook(bookModel);
            _repo.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return Ok(bookReadDto);
        }
    }
}
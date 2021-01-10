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
        [HttpGet("/byCategory/{category}")]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooksByCategory(CategoryOfBook category)
        {
            var bookItems = _repo.GetAllBooksByCategory(category).ToList();
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(bookItems));
        }
        [Authorize]
        [HttpPost]
        public ActionResult<BookReadDto> AddBook(BookAddDto bookAddDto)
        {
            int userId = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            if (Int32.Parse(User.Claims.First(p => p.Type == "id").Value) != userId)
                return Forbid();
            
            var bookModel = _mapper.Map<Book>(bookAddDto);
            bookModel.UserId = userId;
            bookModel.AddedDate = DateTime.Now;
            bookModel.IsAvaible = true;
            _repo.AddBook(bookModel);
            _repo.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return Ok(bookReadDto);
        }
    }
}
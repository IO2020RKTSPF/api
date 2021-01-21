using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class BooksProfile :Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookAddDto, Book>();
        }
    }
}
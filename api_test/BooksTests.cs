using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using api.Controllers;
using api.Data;
using api.DTOs;
using api.Models;
using api.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace api_test
{
    [TestClass]
    public class BooksTests
    {
        [TestMethod]
        public void GetAllBooksTest()
        {
            var myProfile = new BooksProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            
            
            Mock<IPodzielSieKsiazkaRepo> userRepo = new Mock<IPodzielSieKsiazkaRepo>();
            var items = new List<Book>()
            {
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 1,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                },
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 2,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                },
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 3,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                }
            };
            var categoriesOfBooks = Enum.GetValues(typeof(CategoryOfBook))
                .Cast<CategoryOfBook>().ToList();
            userRepo.Setup(m => m.SearchBooks("",categoriesOfBooks,40 ,40,  100000)).Returns(items.AsEnumerable());            
            BooksController controller = new BooksController(
                userRepo.Object,mapper);

            
            
            // Act
            var result = controller.SearchBooks(categoriesOfBooks,"",40 ,40,  100000);

            var itemsDto = mapper.Map<IEnumerable<BookReadDto>>(items).ToList();

            var okResult = result.Result as OkObjectResult;
            IEnumerable<BookReadDto> books = ((IEnumerable<BookReadDto>) okResult?.Value)!.ToList();
            var bookReadDtos = books.ToList();
            Assert.AreEqual(itemsDto.Count(), bookReadDtos.Count());
            Assert.AreEqual(itemsDto.First(p=>p.Id == 1).Author,bookReadDtos.First(p=>p.Id == 1).Author);
            Assert.AreEqual(itemsDto.First(p=>p.Id == 1).Description,bookReadDtos.First(p=>p.Id == 1).Description);
            Assert.AreEqual(itemsDto.First(p=>p.Id == 1).Isbn,bookReadDtos.First(p=>p.Id == 1).Isbn);
        }
        [TestMethod]
        public void GetBookByIdTest()
        {
            var myProfile = new BooksProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            
            Mock<IPodzielSieKsiazkaRepo> userRepo = new Mock<IPodzielSieKsiazkaRepo>();
            var items = new List<Book>()
            {
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 1,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                },
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 2,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                },
                new Book
                {
                    Author = "test 1 author",
                    Category = CategoryOfBook.Fantasy,
                    Description = "asdbsdfsdfsdfs",
                    Id = 3,
                    Isbn = "1234567890",
                    Latitude = 34,
                    Longitude = 34,
                    Owner = new User(),
                    Title = "test 1 title",
                    AddedDate = DateTime.Now,
                    ImgUrl = "cos/url",
                    IsAvaible = true,
                    UserId = 1
                }
            };
            userRepo.Setup(m => m.GetBookById(1)).Returns(items[1]);         
            userRepo.Setup(m => m.GetBookById(2)).Returns(items[2]);
            userRepo.Setup(m => m.GetBookById(0)).Returns(items[0]);            

            BooksController controller = new BooksController(
                userRepo.Object,mapper);
            
            var result = controller.GetBookById(1);
            var okResult = result.Result as OkObjectResult;
            BookReadDto book =  (BookReadDto) okResult?.Value;
            
            Debug.Assert(book != null, nameof(book) + " != null");
            Assert.AreEqual(items[1].Id,book.Id);
            Assert.AreNotEqual(items[2].Id,book.Id);
            Assert.AreEqual(items[1].Category,book.Category);            
        }
    }
}
using System;
using System.Collections.Generic;
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

namespace api_test
{
    [TestClass]
    public class BooksTests
    {
        [TestMethod]
        public void GetAllTest()
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
            userRepo.Setup(m => m.GetAllBooks()).Returns(items.AsEnumerable());            
            BooksController controller = new BooksController(
                userRepo.Object,mapper);

            // Act
            var result = controller.GetAllBooks();

            var itemsDTO = mapper.Map<IEnumerable<BookReadDto>>(items);

            var okResult = result.Result as OkObjectResult;
            IEnumerable<BookReadDto> books = (IEnumerable<BookReadDto>) okResult.Value;
            Assert.AreEqual(itemsDTO.Count(), books.Count());
            Assert.AreEqual(itemsDTO.First(p=>p.Id == 1).Author,books.First(p=>p.Id == 1).Author);
            Assert.AreEqual(itemsDTO.First(p=>p.Id == 1).Description,books.First(p=>p.Id == 1).Description);
            Assert.AreEqual(itemsDTO.First(p=>p.Id == 1).Isbn,books.First(p=>p.Id == 1).Isbn);
        }
    }
}
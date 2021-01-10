using System;
using System.Text.Json.Serialization;
using api.Models;
using Google.Protobuf.WellKnownTypes;

namespace api.DTOs
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsAvaible { get; set; }
        public string Description { get; set; }
        public CategoryOfBook Category { get; set; }
        public string ImgUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public User Owner { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Google.Protobuf.WellKnownTypes;

namespace api.Models
{

    public enum CategoryOfBook
    {
        Fantasy,
        Horror,
        Romans,
        Wojenna,
        Obyczajowa,
        Historyczna
    }
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public bool IsAvaible { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public CategoryOfBook Category { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        public User Owner { get; set; }
    }
}
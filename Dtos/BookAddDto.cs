using System;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs
{
    public class BookAddDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Description { get; set; }
        [Required] 
        public CategoryOfBook Category { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}
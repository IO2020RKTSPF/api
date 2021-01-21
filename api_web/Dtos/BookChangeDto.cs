using api.Models;

namespace api.DTOs
{
    public class BookChangeDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsAvaible { get; set; }
        public string Description { get; set; }
        public CategoryOfBook Category { get; set; }
        public string ImgUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;
using api.Models;

namespace api.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
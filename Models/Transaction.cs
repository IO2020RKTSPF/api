using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Status { get; set; }
        [JsonIgnore]
        public User Customer{ get; set; }       
        [JsonIgnore]
        public Book Book{ get; set; }
        public DateTime DateTimeStart{ get; set; }
        public DateTime DateTimeEnd{ get; set; }
    }
}
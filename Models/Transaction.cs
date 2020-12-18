using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User Customer{ get; set; }       
        [Required]
        public Book Book{ get; set; }
        public DateTime DateTimeStart{ get; set; }
        public DateTime DateTimeEnd{ get; set; }
    }
}
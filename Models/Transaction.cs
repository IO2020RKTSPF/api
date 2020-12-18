using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Transaction
    {
        [Key]
        public int Id;
        [Required]
        public User Owner;
        [Required]
        public User Customer;        
        [Required]
        public Book Book;
        public DateTime DateTimeStart;
        public DateTime DateTimeEnd;
    }
}
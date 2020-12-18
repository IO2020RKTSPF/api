using System;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs
{
    public class TransactionAddDto
    {
        [Required]
        public int CustomerId{ get; set; }   
        [Required]
        public int BookId{ get; set; }
        [Required]
        public int DaysOfRentalTime{ get; set; }
    }
}
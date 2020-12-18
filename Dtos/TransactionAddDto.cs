using System;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs
{
    public class TransactionAddDto
    {
        public int CustomerId{ get; set; }       
        public int BookId{ get; set; }
        public int DaysOfRentalTime{ get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs
{
    public class TransactionAddDto
    {
        public User Owner;
        public User Customer;        
        public Book Book;
        public int WeeksOfRentalTime;
    }
}
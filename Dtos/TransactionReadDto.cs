using System;
using api.Models;

namespace api.DTOs
{
    public class TransactionReadDto
    {
        public int Id;
        public User Owner;
        public User Customer;        
        public Book Book;
        public DateTime DateTimeStart;
        public DateTime DateTimeEnd;
    }
}
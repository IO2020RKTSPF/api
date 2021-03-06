using System;
using api.Models;

namespace api.DTOs
{
    public class TransactionReadDto
    {
        public int Id{ get; set; }
        public string RoomId { get; set; }
        public User Customer{ get; set; }     
        public BookReadDto Book{ get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime DateTimeStart{ get; set; }
        public DateTime DateTimeEnd{ get; set; }
    }
}
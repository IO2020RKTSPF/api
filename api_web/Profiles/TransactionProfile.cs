using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionAddDto, Transaction>();
        }
    }
}
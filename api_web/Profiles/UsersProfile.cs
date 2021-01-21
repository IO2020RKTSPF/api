using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class UsersProfile :Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserAddDto, User>();
        }
    }
}
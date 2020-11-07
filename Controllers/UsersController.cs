using api.Data;
using api.DTOs;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IPodzielSieKsiazkaRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IPodzielSieKsiazkaRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userItem = _repo.GetUserById(id);
            if (userItem == null) return NotFound();
            return Ok(_mapper.Map<UserReadDto>(userItem));
        }
        [HttpGet("login/{id}")]
        public ActionResult<UserReadDto> GetUserByLoginId(string id)
        {
            var userItem = _repo.GetUserByLoginId(id);
            if (userItem == null) return NotFound();
            return Ok(_mapper.Map<UserReadDto>(userItem));
        }

        [HttpPost]
        public ActionResult<UserReadDto> AddUser(UserAddDto userAddDto)
        {
            var userModel = _mapper.Map<User>(userAddDto);
            _repo.AddUser(userModel);
            _repo.SaveChanges();

            //var userReadDto = _mapper.Map<BookReadDto>(userModel);

            return Ok(userModel);
        }
    }
}
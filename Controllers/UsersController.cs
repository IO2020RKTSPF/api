using System;
using System.Collections.Generic;
using api.Data;
using api.DTOs;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


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
        [HttpPost("login")]
        public ActionResult<Object> GetUserByLoginId(string googleId)
        {
            
            var userItem = _repo.GetUserByLoginId(googleId);
            if (userItem == null) return NotFound();
            
            string key = "dlkfjg0934u5tdg54g";
            var issuer = "http://podzielsieksiazka.northeurope.cloudapp.azure.com";
            
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("id",userItem.Id.ToString()));

            var token = new JwtSecurityToken(null,
                null, 
                permClaims,    
                expires: DateTime.Now.AddDays(1),    
                signingCredentials: credentials);    
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);    
            return new { token = jwtToken, user = _mapper.Map<UserReadDto>(userItem)};   
            
            
        }

        [HttpPost]
        public ActionResult<Object> AddUser(UserAddDto userAddDto)
        {

            var userItem = _repo.GetUserByLoginId(userAddDto.LoginId);
            if (userItem != null) 
                return Ok(_mapper.Map<UserReadDto>(userItem));
            var userModel = _mapper.Map<User>(userAddDto);
            _repo.AddUser(userModel);
            _repo.SaveChanges();
            
            
            
            
            string key = "dlkfjg0934u5tdg54g";
            var issuer = "http://podzielsieksiazka.northeurope.cloudapp.azure.com";
            
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("id",userModel.Id.ToString()));

            var token = new JwtSecurityToken(null,
                null, 
                permClaims,    
                expires: DateTime.Now.AddDays(1),    
                signingCredentials: credentials);    
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);    
            
            
            return new{token = jwtToken,user = userModel};
            
        }
    }
}
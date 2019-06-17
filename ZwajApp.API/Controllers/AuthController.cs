using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using ZwajApp.API.DTO;
using ZwajApp.API.Mobels;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepoitory _repo;
        private readonly IConfiguration _config;
  
        public AuthController(IAuthRepoitory repo,IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

        // POST 
        [HttpPost("register")] 
        public  async Task<IActionResult> Register([FromBody]UserForRegisterDTO u){
            //validation
            if(!ModelState.IsValid) return BadRequest(ModelState);

            u.Username = u.Username.ToLower();
            if(await _repo.UserExists(u.Username)) return BadRequest("aready Exit.");

            var newuser = new User();
            newuser.Username = u.Username;

            var CreaqtedUser = await _repo.Register(newuser,u.Password);
            return StatusCode(201);
  
        }


        [HttpPost("login")] 
        public  async Task<IActionResult> login(UserForLoginDTO u){
                               
            User user = await _repo.Login(u.Username.ToLower(),u.Password);

            if(user == null) return Unauthorized(); 

            var claims = new []{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username)
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));

            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha512);

            var TokenDescriptor  = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var Token = TokenHandler.CreateToken(TokenDescriptor);
            
            return Ok(new{token =TokenHandler.WriteToken(Token)});

        }




    }
}

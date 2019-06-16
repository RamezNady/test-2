using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using ZwajApp.API.DTO;
using ZwajApp.API.Mobels;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepoitory _repo;
        public AuthController(IAuthRepoitory repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {            
            UserForRegisterDTO u = new UserForRegisterDTO();
            u.Username = "ll";
            u.Password = "12312345678879";

            //var newuser = new User();
           // newuser.Username = u.Username;
            var newuser = new User{
                Username = u.Username
            };


            var CreaqtedUser = _repo.Register(newuser,u.Password);
            
            return new string[] { "value1", "value2" };
        }

        // POST 
        [HttpPost("register")] 
        public  async Task<IActionResult> Register([FromBody]UserForRegisterDTO u){
            //validation


            u.Username = u.Username.ToLower();
            if(await   _repo.UserExists(u.Username)) return BadRequest("aready Exit.");

            var newuser = new User{
                Username = u.Username
            };

            var CreaqtedUser = await _repo.Register(newuser,u.Password);
            return StatusCode(201);
  
        }









    }
}

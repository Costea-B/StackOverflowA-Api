using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;

namespace StackOverflow.API.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    public class UsersController : ControllerBase
    {
         private readonly IUsersServices _userService;


         public UsersController(IUsersServices userService)
         {
              _userService = userService;
         }

        [HttpPost("Create")]
        public IActionResult Create(UserModel user)
        {
            // TODO: add actual function calls
            return CreatedAtAction(nameof(LoginUser), new { id = user.Id }, user);
        }

        [HttpGet("LoginUser/{id}")]
        public UserModel LoginUser( int id, string name, string password)
        {
             var user = new UserModel( id, name, "joric",password );
            return _userService.LoginUsers(user);
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromQuery] string email, string password)
        {
             UserModel user = new UserModel(0, email, email, password);
             var users = _userService.LoginUsers(user);
             if (users != null)
             {
                  return Ok();
             }

               return  Problem();
          }

    }
}

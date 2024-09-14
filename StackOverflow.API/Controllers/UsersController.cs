using Core.Models;
using Core.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegRequest user)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            // TODO: add custom validators

            //var response = await _userService.Register(user);
            var response = await Task.FromResult(0);

            return Ok(response);
        }

        //[HttpGet("LoginUser/{id}")]
        //public UserModel LoginUser(int id, string name, string password)
        //{
        //    var user = new UserModel(id, name, "joric", password);
        //    return _userService.LoginUser(user);
        //}


        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromQuery] string email, string password)
        {
             UserModel user = new UserModel(0, email, email, password);
             var users = _userService.LoginUser(user);
             if (users != null)
             {
                  return Ok();
             }

               return  Problem();
          }

    }
}

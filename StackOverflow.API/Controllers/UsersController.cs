using Core.Models;
using Core.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;

namespace StackOverflow.API.Controllers
{
  
    /*
     * eu si costea avem diferite taburi/spaceuri
     * dbcontext trebu injectat? (in cazu ista ar trebui un singur repo si nare sens)
     * 
     * 
     * 
     * 
     * 
     */


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

            var response = await _userService.Register(user);
            
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
        public IActionResult Login(UserModel user)
        {
            IActionResult response = Unauthorized();

            if (user?.Name == "foo" && user?.Password == "bar")
            {
                response = Ok();
            }

            return response;
        }

    }
}

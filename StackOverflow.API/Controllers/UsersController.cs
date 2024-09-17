using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
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
         
         [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegRequest user)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            // TODO: add custom validators

            var response = await _userService.Register(user);
            
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel user)
        {
               
             
             //var users = _userService.LoginUser(user);
            // if (users != null)
            // {
            //      return Ok();
            // }
            //
            return Ok();
        }

    }
}

using System.IdentityModel.Tokens.Jwt;
using Core.Models;
using Core.Models.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;

namespace StackOverflow.API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersServices _usersService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JwtProvid _jwtProvid;
        private readonly CurrentUserServices _current;
        
        public AuthController(IUsersServices usersServices, IHttpContextAccessor accessor, JwtProvid jwtProvid, CurrentUserServices current) 
        {
            _usersService = usersServices;
            _contextAccessor = accessor;
            _jwtProvid = jwtProvid;
            _current = current;
        }


        [HttpGet("getUser/me")]
        public async Task<IActionResult> GetUser()
        {
             var currentUser = new
             {
                  UserName = _current.UserName,
                  UserId = _current.UserId,
             };

             return Ok(currentUser);
          }
        
       [HttpPost("login")]
       [AllowAnonymous]
       public async Task<IActionResult> login([FromBody] UserLoginRequest userModel)
       {
           var token = await _usersService.Login(userModel);
       
       //       if (user == null)
       //       {
       //           return Unauthorized(new { message = "Invalid credentials" });
       //       }
       //       
       //   var token = _jwtProvid.GenerateJwtToken(user);

       if (token == null)
       {
            return Unauthorized(new { message = "Invalid credentials" });
       }

       return Ok(new { token });

       }

       [HttpPost("logout")]
       public IActionResult logout()
       {
           Response.Cookies.Delete("JwtToken");
           return Ok(new { message = "Logout successful" });
       }
       
       [HttpPost("register")]
       [AllowAnonymous]
       public async Task<IActionResult> Register(UserRegRequest user)
       {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _usersService.Register(user);

            return Ok(response);
       }
     }
}
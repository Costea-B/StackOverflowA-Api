using Azure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;
using System;

namespace StackOverflow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersServices _usersService;
        private readonly JwtProvid _jwtProvid;

        public AuthController(IUsersServices usersServices, JwtProvid jwtProvid) 
        {
            _usersService = usersServices;
            _jwtProvid = jwtProvid;
        }

        //[HttpPost("login")]
        //public IActionResult login([FromBody] UserModel userModel)
        //{
        //    var user = _usersService.LoginUsers(userModel);

        //    if (user == null)
        //    {
        //        return Unauthorized(new { message = "Invalid credentials" });
        //    }

        //    var token = _jwtProvid.GenerateJwtToken(user);

        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Secure = true,
        //        Expires = DateTime.UtcNow.AddMinutes(30),
        //        SameSite = SameSiteMode.Strict
        //    };

        //    Response.Cookies.Append("JwtToken", token, cookieOptions);

        //    return Ok(new { message = "Login successful" });
        //}

        //[HttpPost("logout")]
        //public IActionResult logout()
        //{
        //    Response.Cookies.Delete("JwtToken");
        //    return Ok(new { message = "Logout successful" });
        //}
    }
}

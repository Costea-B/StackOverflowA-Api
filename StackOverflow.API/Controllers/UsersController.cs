using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StackOverflow.API.Controllers
{
    //this class will be replaced
    public class Usr
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    public class UsersController : ControllerBase
    {
        [HttpPost("Create")]
        public IActionResult Create(Usr user)
        {
            // TODO: add actual function calls
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = new Usr() { Id = id, Name = "foo", Password = "bar" };
            return new ObjectResult(user);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(Usr user)
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

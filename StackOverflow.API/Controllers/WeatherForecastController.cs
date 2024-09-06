using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace StackOverflow.API.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class WeatherForecastController : ControllerBase
     {
          private readonly IUserService _usersService;

     
          private static readonly string[] Summaries = new[]
          {
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

          private readonly ILogger<WeatherForecastController> _logger;

          public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService)
          {
               _logger = logger;
               _usersService = userService;
          }

          [HttpGet(Name = "GetWeatherForecast")]
          public IEnumerable<WeatherForecast> Get([FromRoute] int test)
          {
               return Enumerable.Range(1, 5).Select(index => new WeatherForecast
               {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
               })
               .ToArray();
          }

          [HttpGet("testing/{id}")]
          public UserModel Test([FromRoute] string id, [FromQuery] int age)
          {

               return _usersService.create(age);
          }

          [HttpPost("testing")]
          public int TestJson([FromBody] UserModel user)
          {
               return user.Id;
          }
     }
}

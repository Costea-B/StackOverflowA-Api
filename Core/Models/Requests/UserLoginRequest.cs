using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Requests
{
     public class UserLoginRequest(string email, string password)
     {
          public string Email { get; set; } = email;
          public string Password { get; set; } = password;
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
     public class UserModel
     {
          public UserModel(int id, string name, string email, string password)
          {
               Id = id;
               Name = name;
               Email = email;
               Password = password;
          }
          public int Id { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }

     }
}

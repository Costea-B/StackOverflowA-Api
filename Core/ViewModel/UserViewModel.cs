using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
     public class UserViewModel
     {
          public UserViewModel (int id, string email, string name)
          {
               Id = id;
               Email = email;
               Name = name;
          }
          public int Id { get; set; }
          public string Email { get; set; }
          public string Name { get; set; }

     }
}

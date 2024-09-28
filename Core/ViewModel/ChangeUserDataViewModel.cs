using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
     public class ChangeUserDataViewModel
     {
          public ChangeUserDataViewModel(int id, string name, string email, string currentPassword, string newPassword)
          {
               Id = id;
               Name = name;
               Email = email;
               CurrentPassword = currentPassword;
               NewPassword = newPassword;
          }

          public int Id { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string CurrentPassword { get; set; }
          public string NewPassword { get; set; }
     }
}

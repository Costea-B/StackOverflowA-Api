using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
     public class UpdateUserViewModel
     {
          public string Name { get; set; }
          public string Email { get; set; }
          public string CurrentPassword { get; set; }
          public string NewPassword { get; set; }
     }
}

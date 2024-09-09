using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Services.Abstractions
{
     public interface IUsersServices
     {
          UserModel LoginUsers(UserModel users);
          UserModel CreateNewUsers(UserModel users);
     }
}

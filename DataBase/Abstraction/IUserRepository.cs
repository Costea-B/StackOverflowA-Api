using Core.Models.Requests;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace DataBase.Abstraction
{
     public interface IUserRepository
     {
          Task<RegisterViewModel> Register(UserRegRequest user);
          UserModel LoginUsers(UserModel user);
     }
}

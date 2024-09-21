using Core.Models.Requests;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DbModels;

namespace DataBase.Abstraction
{
     public interface IUserRepository
     {
          Task<UserRegRequest> Register(UserRegRequest user);
          Task<UserModel> LoginUsers(UserLoginRequest  user);
        Task<List<UserViewModel>> GetUsersAsync();
    }
}

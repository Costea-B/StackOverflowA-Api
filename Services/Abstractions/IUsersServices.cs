using Core.DbModels;
using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Services.Abstractions
{
    public interface IUsersServices
     {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<string> Login(UserLoginRequest users);
          Task<UserRegRequest> Register(UserRegRequest user);
     }
}

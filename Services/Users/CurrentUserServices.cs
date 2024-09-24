using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ViewModel;
using DataBase.Abstraction;
using Microsoft.AspNetCore.Http;
using Services.Abstractions;

namespace Services.Users
{
     public class CurrentUserServices: ICurrentUserServices
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IUserRepository _userRepository;

          public CurrentUserServices(IHttpContextAccessor httpContextAccessor, IUserRepository repository)
          {
               _httpContextAccessor = httpContextAccessor;
               _userRepository = repository;
          }


          public async Task<UserViewModel> GetUser()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _userRepository.GetUser(Int32.Parse(userIdClaim));
                    
          }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Requests;
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
          private readonly ITopicService _topicRepository;

          public CurrentUserServices(IHttpContextAccessor httpContextAccessor, IUserRepository repository, ITopicService topic)
          {
               _httpContextAccessor = httpContextAccessor;
               _userRepository = repository;
               _topicRepository = topic;
          }


          public async Task<UserViewModel> GetUser()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _userRepository.GetUser(Int32.Parse(userIdClaim));
                    
          }

          public async Task<int> CreateTopic(CreateTopicRequest request)
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               var topicId = await _topicRepository.CreateTopicAsync(request, Int32.Parse(userIdClaim));
               return topicId;
          }
     }
}

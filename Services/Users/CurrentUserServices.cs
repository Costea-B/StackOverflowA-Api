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
using Services.Topic;

namespace Services.Users
{
     public class CurrentUserServices: ICurrentUserServices
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IUserRepository _userRepository;
          private readonly ITopicService _topicService;

          public CurrentUserServices(IHttpContextAccessor httpContextAccessor, IUserRepository repository, ITopicService topic)
          {
               _httpContextAccessor = httpContextAccessor;
               _userRepository = repository;
               _topicService = topic;
          }


          public async Task<UserViewModel> GetUser()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _userRepository.GetUser(Int32.Parse(userIdClaim));
                    
          }

          public async Task<int> CreateTopic(CreateTopicRequest request)
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               var topicId = await _topicService.CreateTopicAsync(request, Int32.Parse(userIdClaim));
               return topicId;
          }


          public async Task<List<TopicViewModel>> GetTopicsByUserIdAsync()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _topicService.GetTopicsByUserIdAsync(Int32.Parse(userIdClaim));
          }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
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
          private readonly IReplyService _replyService;
          private readonly IUsersServices _usersService;

          public CurrentUserServices(IHttpContextAccessor httpContextAccessor, IUserRepository repository, ITopicService topic, IReplyService replyService, IUsersServices usersService)
          {
               _httpContextAccessor = httpContextAccessor;
               _userRepository = repository;
               _topicService = topic;
               _replyService = replyService;
               _usersService = usersService;
          }


          public async Task<UserViewModel> GetUser()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _userRepository.GetUser(Int32.Parse(userIdClaim));
                    
          }

          public async Task<int> CreateTopic(CreateTopicRequest request)
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               var topicId = await _topicService.CreateTopicAsync(request, 1);
               return topicId;
          }


          public async Task<List<TopicViewModel>> GetTopicsByUserIdAsync()
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               return await _topicService.GetTopicsByUserIdAsync(Int32.Parse(userIdClaim));
          }

          public async Task CreateReply(int topicId, string description)
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               await _replyService.CreateReplyAsync(new CreateReplyRequest(1, description, topicId));
          }

          public async Task ChangeUserData(string email, string name, string currentPassword, string newPassword)
          {
               var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
               
              await _usersService.ChangeUserData(new ChangeUserDataViewModel(Int32.Parse(userIdClaim), name,
                    email, currentPassword, newPassword));

             // await _usersService.ChangeUserData(new UserModel(user.Id, name, email, newPassword), user.Password, currentPassword);
          }
     }
}

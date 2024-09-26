﻿using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using DataBase.Repositories;
using DataBase.Abstraction;
using Services.Abstractions;
using Core.Models.Requests;
using Core.Models;
using Core.ViewModel;

namespace Services.Topic
{

     public class TopicService : ITopicService
     {
          private readonly ITopicRepository _topicRepository;

          public TopicService(ITopicRepository topicRepository)
          {
               _topicRepository = topicRepository;
          }

          public async Task<TopicViewModel> GetTopicByIdAsync(int id)
          {
               return await _topicRepository.GetByIdAsync(id);
          }

          public async Task<List<AllTopicViewModel>> GetAllTopicsAsync()
          {
               var topics = await _topicRepository.GetAllAsync();
               return topics.Select(topic => new AllTopicViewModel(topic)).ToList();
          }

          public async Task<TopicViewModel> CreateTopicAsync(CreateTopicRequest request)
          {
               var newTopic = new TopicDbTables
               {
                    Title = request.Title,
                    Description = request.Description,
                    Datecreate = DateTime.UtcNow,
                    Tags = request.Tags,
                    UserId = request.UserId
               };

               await _topicRepository.AddAsync(newTopic);

               var topicViewModel = await _topicRepository.GetByIdAsync(newTopic.Id);

               return topicViewModel;
          }

          public async Task<bool> DeleteTopicAsync(int id)
          {
               bool status = await _topicRepository.DeleteAsync(id);
               return status;
          }



          public async Task<IEnumerable<TopicViewModel>> SearchTopicsAsync(string searchTerm)
          {
               return await _topicRepository.SearchTopicsAsync(searchTerm);
          }

          public async Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId)
          {
               return await _topicRepository.GetTopicsByUserIdAsync(userId);
          }
     }
}

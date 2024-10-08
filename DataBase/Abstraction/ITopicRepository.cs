﻿using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Abstraction
{
    public interface ITopicRepository
    {
        Task<TopicViewModel> GetByIdAsync(int id);
        Task<List<TopicDbTables>> GetAllAsync();
        Task<int> AddAsync(TopicDbTables topic);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TopicViewModel>> SearchTopicsAsync(string searchTerm);
        Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId);
    }
}

using Core.DbModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITopicService
    {
        Task<TopicDbTables> GetTopicByIdAsync(int id);
        Task<List<TopicDbTables>> GetAllTopicsAsync();
        Task<TopicDbTables> CreateTopicAsync(CreateTopicRequest request);
        Task<bool> DeleteTopicAsync(int id);

        Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId);
    }

}

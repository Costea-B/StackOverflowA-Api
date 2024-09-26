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
        Task<TopicViewModel> GetTopicByIdAsync(int id);
        Task<List<TopicViewModel>> GetAllTopicsAsync();
        Task<TopicViewModel> CreateTopicAsync(CreateTopicRequest request);
        Task<bool> DeleteTopicAsync(int id);

        Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId);
        Task<IEnumerable<TopicDbTables>> SearchTopicsAsync(string searchTerm);
    }

}

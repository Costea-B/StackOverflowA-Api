using Core.DbModels;
using Core.Models.Requests;
using Core.ViewModel;
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
        Task<List<TopicViewModel>> GetAllTopicsAsync();
        Task<TopicDbTables> CreateTopicAsync(CreateTopicRequest request);
        Task<bool> DeleteTopicAsync(int id);

        Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId);
        Task<IEnumerable<TopicDbTables>> SearchTopicsAsync(string searchTerm);
    }

}

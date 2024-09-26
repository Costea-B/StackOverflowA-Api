using Core.DbModels;
using Core.Models.Requests;
using Core.ViewModel;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Requests;
using Core.ViewModel;

namespace Services.Abstractions
{
    public interface ITopicService
    {
        Task<TopicViewModel> GetTopicByIdAsync(int id);
        Task<List<TopicViewModel>> GetAllTopicsAsync();
        Task<TopicViewModel> CreateTopicAsync(CreateTopicRequest request);
        Task<bool> DeleteTopicAsync(int id);

        Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId);
        Task<IEnumerable<TopicViewModel>> SearchTopicsAsync(string searchTerm);
    }

}

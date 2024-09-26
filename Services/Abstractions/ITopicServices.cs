using Core.DbModels;
using Core.Models;
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
        Task<TopicViewModel> GetTopicByIdAsync(int id);
        Task<List<TopicViewModel>> GetAllTopicsAsync();
        Task<TopicViewModel> CreateTopicAsync(CreateTopicRequest request);
        Task<bool> DeleteTopicAsync(int id);

        Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId);
    }

}

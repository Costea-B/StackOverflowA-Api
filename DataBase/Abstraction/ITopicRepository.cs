using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public interface ITopicRepository
    {
        Task<TopicViewModel> GetByIdAsync(int id);
        Task<List<TopicViewModel>> GetAllAsync();
        Task AddAsync(TopicDbTables topic);

        Task<bool> DeleteAsync(int id);

        Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId);
    }
}

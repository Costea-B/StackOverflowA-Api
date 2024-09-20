using Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public interface ITopicRepository
    {
        Task<TopicDbTables> GetByIdAsync(int id);
        Task<List<TopicDbTables>> GetAllAsync();
        Task AddAsync(TopicDbTables topic);

        Task<bool> DeleteAsync(int id);

        Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId);
    }
}

using Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Abstraction
{
    public interface ITopicRepository
    {
        Task<TopicDbTables> GetByIdAsync(int id);
        Task<List<TopicDbTables>> GetAllAsync();
        Task AddAsync(TopicDbTables topic);
    }
}

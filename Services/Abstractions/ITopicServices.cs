using Core.DbModels;
using Core.Models;
using System;
using System.Collections.Generic;
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
    }

}

using Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public interface IReplyRepository
    {
        Task CreateAsync(ReplyDbTables reply);
        Task<ReplyDbTables> GetByIdAsync(int replyId);
        Task<List<ReplyDbTables>> GetAllForTopicAsync(int topicId);
        Task<ReplyDbTables> UpdateAsync(int replyId, string newDescription);
    }
}

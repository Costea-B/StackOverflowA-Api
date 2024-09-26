using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Requests;

namespace Services.Abstractions
{
    public interface IReplyService
    {
        Task<ReplyDbTables> CreateReplyAsync(CreateReplyRequest request);
        Task<ReplyViewModel> GetReplyByIdAsync(int id);
        Task<List<ReplyViewModel>> GetRepliesForToticAsync(int topicId);
        Task<ReplyDbTables> UpdateReplyAsync(int replyId, string newDescription);
        Task<List<ReplyViewModel>> GetRepliesForTopicAsync(int topicId);
        Task<List<ReplyViewModel>> GetRepliesByUserIdAsync(int userId);
        Task DeleteReplyAsync(int replyId);
        Task SubmitRatingAsync(int replyId, int rating);
    }
}

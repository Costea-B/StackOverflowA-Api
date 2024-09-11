﻿using Core.DbModels;
using Core.Models;
using Core.ViewModel;
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
        Task<ReplyDbTables> CreateToReplyAsync(int parentId,CreateReplyRequest request);
        Task<List<ReplyViewModel>> GetRepliesAsync(int topicId);
        Task DeleteAsync(int replyId);
    }
}

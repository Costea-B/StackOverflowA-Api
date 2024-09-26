﻿using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using DataBase.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Abstraction;

namespace Services.Topic
{
    public class ReplyServices : IReplyService
    {
        private readonly IReplyRepository _replyRepository;

        public ReplyServices(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }
        public async Task<ReplyViewModel> CreateReplyAsync(CreateReplyRequest reply)
        {
            var newReply = new ReplyDbTables(reply.AuthorId, reply.Description, reply.TopicId);

            await _replyRepository.CreateAsync(newReply);

            var replyViewModel = await _replyRepository.GetByIdAsync(newReply.Id);

            return replyViewModel;
        }

        public async Task<ReplyViewModel> GetReplyByIdAsync(int id)
        {
            return await _replyRepository.GetByIdAsync(id);
        }

        public async Task<List<ReplyViewModel>> GetRepliesForToticAsync(int topicId)
        {
            return await _replyRepository.GetAllForTopicAsync(topicId);
        }

        public async Task<ReplyDbTables> UpdateReplyAsync(int replyId, string newDescription)
        {
            return await _replyRepository.UpdateAsync(replyId, newDescription);
        }

        public async Task<List<ReplyViewModel>> GetRepliesForTopicAsync(int topicId)
        {
            return await _replyRepository.GetRepliesAsync(topicId);
        }

        public async Task DeleteReplyAsync(int replyId)
        {
            await _replyRepository.DeleteAsync(replyId);
        }

        public async Task<List<ReplyViewModel>> GetRepliesByUserIdAsync(int userId)
        {
            return await _replyRepository.GetByUserIdAsync(userId);
        }
    }
}

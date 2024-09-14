using Core.DbModels;
using Core.Models;
using Core.ViewModel;
using Services.Abstractions;
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
        public async Task<ReplyDbTables> CreateReplyAsync(CreateReplyRequest reply)
        {
            var newReply = new ReplyDbTables(reply.AuthorId, reply.Description, reply.TopicId);

            await _replyRepository.CreateAsync(newReply);
            return newReply;
        }

        public async Task<ReplyDbTables> GetReplyByIdAsync(int id)
        {
            return await _replyRepository.GetByIdAsync(id);
        }

        public async Task<List<ReplyDbTables>> GetRepliesForToticAsync(int topicId)
        {
            return await _replyRepository.GetAllForTopicAsync(topicId);
        }

        public async Task<ReplyDbTables> UpdateReplyAsync(int replyId, string newDescription)
        {
            return await _replyRepository.UpdateAsync(replyId, newDescription);
        }

        public async Task<ReplyDbTables> CreateReplyToReplyAsync(int parentReplyId, CreateReplyRequest request)
        {
            return await _replyRepository.CreateToReplyAsync(parentReplyId, request);
        }

        public async Task<List<ReplyViewModel>> GetRepliesForTopicAsync(int topicId)
        {
            return await _replyRepository.GetRepliesAsync(topicId);
        }

        public async Task DeleteReplyAsync(int replyId)
        {
            await _replyRepository.DeleteAsync(replyId);
        }
    }
}

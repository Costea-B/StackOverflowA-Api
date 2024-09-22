using Core.DbModels;
using DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.ViewModel;
using DataBase.Abstraction;
using Newtonsoft.Json;

namespace DataBase.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly AppDbContext _context;

        public ReplyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ReplyDbTables reply)
        {
            _context.ReplyDbTables.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task<ReplyDbTables> CreateToReplyAsync(int parentReplyId, CreateReplyRequest request)
        {
            var parentReply = await _context.ReplyDbTables.FindAsync(parentReplyId);
            if (parentReply == null)
            {
                throw new Exception("Parent reply not found");
            }
            var newReply = new ReplyDbTables(request.AuthorId, request.Description, request.TopicId);

            _context.ReplyDbTables.Add(newReply);
            await _context.SaveChangesAsync();

            return newReply;
        }

        public async Task<List<ReplyDbTables>> GetAllForTopicAsync(int topicId)
        {
            var replies = await _context.ReplyDbTables.Where(r => r.TopicId == topicId).ToListAsync();
            return replies;
        }

        public async Task<ReplyDbTables> GetByIdAsync(int id)
        {
           //  await _context.Database.MigrateAsync();
            var reply = await _context.ReplyDbTables.FindAsync(id);
            if (reply == null)
            {
                throw new Exception($"Reply with ID {id} not found.");
            }
            return reply;
        }

        public async Task<List<ReplyViewModel>> GetRepliesAsync(int topicId)
        {
            var replies = await _context.ReplyDbTables
                .Where(r => r.TopicId == topicId)
                .ToListAsync();
            var replyViewModels = replies.Select(r => new ReplyViewModel(r.Id, r.AuthorId, r.Description, r.CreatedAt)).ToList();

            return replyViewModels;
        }

        public async Task<ReplyDbTables> UpdateAsync(int replyId, string newDescription)
        {
            var reply = await _context.ReplyDbTables.FindAsync(replyId);
            if(reply == null)
            {
                throw new Exception($"Reply with ID {replyId} not found.");
            }
            reply.Description = newDescription;
            await _context.SaveChangesAsync();

            return reply;
        }

        public async Task DeleteAsync(int replyId)
        {
            var reply = await _context.ReplyDbTables.FirstOrDefaultAsync(r => r.Id == replyId);
            if (reply == null)
            {
                throw new Exception($"Reply with ID {replyId} not found.");
            }

            _context.ReplyDbTables.Remove(reply);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitRatingAsync(int replyId, int rating)
        {
            var reply = await _context.ReplyDbTables.FindAsync(replyId);
            
            if (reply != null)
            {
                reply.Ratings.Add(rating);
                _context.ReplyDbTables.Update(reply);
                await _context.SaveChangesAsync();
            }
        }
       
    }
}

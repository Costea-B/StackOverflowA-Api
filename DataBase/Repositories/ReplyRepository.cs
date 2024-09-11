using Core.DbModels;
using DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ReplyDbTables>> GetAllForTopicAsync(int topicId)
        {
            var replies = await _context.ReplyDbTables.Where(r => r.TopicId == topicId).ToListAsync();
            return replies;
        }

        public async Task<ReplyDbTables> GetByIdAsync(int id)
        {
             await _context.Database.MigrateAsync();
            var reply = await _context.ReplyDbTables.FindAsync(id);
            if (reply == null)
            {
                throw new Exception($"Reply with ID {id} not found.");
            }
            return reply;
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
    }
}

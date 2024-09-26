using Core.DbModels;
using DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Models.Requests;
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
             // Găsește utilizatorul și topicul aferent pentru răspunsul curent
             var user = await _context.UserDbTables.FindAsync(reply.AuthorId);
             var topic = await _context.TopicDbTables.FindAsync(reply.TopicId);

             // Verifică dacă utilizatorul sau topicul sunt null
             if (user == null)
             {
                  throw new Exception("User not found");
             }
             if (topic == null)
             {
                  throw new Exception("Topic not found");
             }

             // Inițializează colecția de răspunsuri dacă nu este inițializată
             user.Replies ??= new List<ReplyDbTables>();
             topic.Replies ??= new List<ReplyDbTables>();

             // Adaugă răspunsul în colecțiile utilizatorului și ale topicului
             user.Replies.Add(reply);
             topic.Replies.Add(reply);

             // Adaugă răspunsul în baza de date
             _context.ReplyDbTables.Add(reply);

             // Salvează modificările
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

        public async Task<List<ReplyViewModel>> GetAllForTopicAsync(int topicId)
        {
            var replies = await _context.ReplyDbTables
                .Include(r => r.Author)
                .Include(r => r.Topic)
                .Where(r => r.TopicId == topicId)
                .ToListAsync();
            var replyViewModels = replies.Select(r => new ReplyViewModel(r.Id, r.AuthorId, r.TopicId, r.Description, r.CreatedAt, r.Author?.Name ?? "Unknown Author", r.Topic.Title)).ToList();
            return replyViewModels;
        }

        public async Task<ReplyViewModel> GetByIdAsync(int id)
        {
            var reply = await _context.ReplyDbTables
                .Include(r => r.Author)
                .Include(r => r.Topic)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reply == null)
            {
                throw new Exception($"Reply with ID {id} not found.");
            }
            var replyViewModel = new ReplyViewModel(reply.Id, reply.AuthorId,reply.TopicId, reply.Description, reply.CreatedAt, reply.Author?.Name ?? "Unknown Author", reply.Topic.Title);
            return replyViewModel;
        }

        public async Task<List<ReplyViewModel>> GetRepliesAsync(int topicId)
        {
            var replies = await _context.ReplyDbTables
                .Include(r => r.Author)
                .Include(r => r.Topic)
                .Where(r => r.TopicId == topicId)
                .ToListAsync();
            var replyViewModels = replies.Select(r => new ReplyViewModel(r.Id, r.AuthorId, r.TopicId, r.Description, r.CreatedAt, r.Author?.Name ?? "Unknown Author", r.Topic.Title)).ToList();

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

        public async Task<List<ReplyViewModel>> GetByUserIdAsync(int userId)
        {
            var reply = await _context.ReplyDbTables
                .Include(r => r.Author)
                .Include(r => r.Topic)
                .Where(r => r.AuthorId == userId)
                .ToListAsync();
            var replyViewModels = reply.Select(r => new ReplyViewModel(r.Id, r.AuthorId, r.TopicId, r.Description, r.CreatedAt, r.Author?.Name ?? "Unknown Author", r.Topic.Title)).ToList();
            return replyViewModels;
        }
    }
}

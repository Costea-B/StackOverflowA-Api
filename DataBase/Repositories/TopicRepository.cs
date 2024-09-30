using Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using DataBase.Context;
using DataBase.Abstraction;
using Core.ViewModel;

namespace DataBase.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TopicViewModel> GetByIdAsync(int id)
        {
             //aici e doar pentru megrarea initiala a datelor fara alt ceva, date in tabel nu vor fi introduci manual nu si lenos)

             //  await _context.Database.MigrateAsync();
               var topic = await _context.TopicDbTables
                .Include(t => t.User)
                
                .FirstOrDefaultAsync(t => t.Id == id);

            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with ID {id} not found.");
            }
            var topicViewModel = new TopicViewModel
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                Tags = topic.Tags,
                User = new UserViewModel(topic.User.Id, topic.User.Email, topic.User.Name),
            };

            return topicViewModel;
        }


        public async Task<List<TopicDbTables>> GetAllAsync()
        {
            var topics = await _context.TopicDbTables
                .Include(t => t.User)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.Author)
                .ToListAsync();

            

            return topics;
        }

        public async Task<int> AddAsync(TopicDbTables topic)
        {
            _context.TopicDbTables.Add(topic);
            await _context.SaveChangesAsync();
            return topic.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
             var topic = await _context.TopicDbTables.FirstOrDefaultAsync(t => t.Id == id);
             if (topic == null)
             {
                  return false;
             }
             _context.TopicDbTables.Remove(topic);
             await _context.SaveChangesAsync();
             return true;
        }

        public async Task<List<TopicViewModel>> GetTopicsByUserIdAsync(int userId)
        {
            var topics = await _context.TopicDbTables
                .Include(t => t.User)
                .Where(t => t.UserId == userId)
                .ToListAsync();

            if (topics == null)
            {
                throw new KeyNotFoundException("No topics found.");
            }
            var topicViewModel = topics.Select(topic => new TopicViewModel
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                Tags = topic.Tags,
                User = new UserViewModel(topic.User.Id, topic.User.Email, topic.User.Name),
            }).ToList();

            return topicViewModel;
        }

        public async Task<IEnumerable<TopicViewModel>> SearchTopicsAsync(string searchTerm)
        {
            var topics = await _context.TopicDbTables
                .Where(t => t.Title.Contains(searchTerm) )
                .ToListAsync();

               var topicViewModel = topics.Select(topic => new TopicViewModel
               {
                    Id = topic.Id,
                    Title = topic.Title,
                    Description = topic.Description,
                    Tags = topic.Tags,
                    User = new UserViewModel(topic.User.Id, topic.User.Email, topic.User.Name),
               }).ToList();

               return topicViewModel;
          }
        
    }
}

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

namespace DataBase.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TopicDbTables> GetByIdAsync(int id)
        {
             //aici e doar pentru megrarea initiala a datelor fara alt ceva, date in tabel nu vor fi introduci manual nu si lenos)

             //  await _context.Database.MigrateAsync();
               var topic = await _context.TopicDbTables.FindAsync(id);

            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with ID {id} not found.");
            }

            return topic;
        }


        public async Task<List<TopicDbTables>> GetAllAsync()
        {
            return await _context.TopicDbTables.ToListAsync();
        }

        public async Task AddAsync(TopicDbTables topic)
        {
            _context.TopicDbTables.Add(topic);
            await _context.SaveChangesAsync();
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

        public async Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId)
        {
            return await _context.TopicDbTables
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TopicDbTables>> SearchTopicsAsync(string searchTerm)
        {
            return await _context.TopicDbTables
                .Where(t => t.Title.Contains(searchTerm) || t.Tags.Any(tag => tag.Contains(searchTerm)))
                .ToListAsync();
        }
        
    }
}

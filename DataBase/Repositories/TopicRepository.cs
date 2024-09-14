using Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // await _context.Database.MigrateAsync();
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
    }
}

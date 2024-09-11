using Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Context;

namespace DataBase.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TopicDbTables> GetByIdAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with ID {id} not found.");
            }

            return topic;
        }


        public async Task<List<TopicDbTables>> GetAllAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task AddAsync(TopicDbTables topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
        }
    }
}

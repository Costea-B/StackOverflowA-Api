using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Context;

namespace Services.Users
{
    public class TopicService
    {
        private readonly AppDbContext _context;

        TopicService(AppDbContext context)
        {
            _context = context;
        }

        public ReplyModel CreateReply(CreateReplyRequest request) {
            var topic = _context.TopicDbTables.Find(request);
            var reply = new ReplyModel()
            {
                AuthorId = topic.UserId,
                Description = topic.Description,
                TopicId = topic.Id,
            };

            _context.ReplyDbTables.Add(reply);

            return reply;

        }
    }
}

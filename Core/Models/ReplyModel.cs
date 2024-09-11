using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ReplyModel
    {

        public ReplyModel(int id, int authorId, string description, DateTime createdAt, int topicId, TopicModel topic, UserModel user)
        {
            Id = id;
            AuthorId = authorId;
            Description = description;
            CreatedAt = createdAt;
            TopicId = topicId;
            Topic = topic;
            User = user;
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int TopicId { get; set; }
        public TopicModel Topic { get; set; }
        public UserModel User { get; set; }
    }
}

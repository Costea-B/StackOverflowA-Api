using Core.DbModels;
using Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class ReplyViewModel
    {
        public ReplyViewModel(int id, int? authorId,int? topicId, string description, DateTime createdAt, string author, string topic) 
        {
            Id = id;
            AuthorId = authorId;
            TopicId = topicId;
            Description = description;
            CreatedAt = createdAt;
            AuthorName = author;
            TopicName = topic;
        }

        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int? TopicId { get; set; }
        public string AuthorName { get; set; }
        public string TopicName { get; set; }
    }
}

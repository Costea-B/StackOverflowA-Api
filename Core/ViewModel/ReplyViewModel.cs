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
        public ReplyViewModel(int id, int? authorId, string description, DateTime createdAt,List<ReplyViewModel> childReplies) 
        {
            Id = id;
            AuthorId = authorId;
            Description = description;
            CreatedAt = createdAt;
            ChildReplies = childReplies;
        }

        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int TopicId { get; set; }
        public string AuthorName { get; set; }
        public List<ReplyViewModel> ChildReplies { get; set; }
    }
}

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
        public ReplyViewModel(int id, int? authorId, string description, DateTime createdAt, string author, List<int> ratings) 
        {
            Id = id;
            AuthorId = authorId;
            Description = description;
            CreatedAt = createdAt;
            AuthorName = author;
            if (ratings != null && ratings.Count != 0)
            {
                 Ratings = Math.Round((decimal)ratings.Sum() / ratings.Count, 1);
               }
            else
            {
                Ratings = 0; 
            }
            
        }

        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string AuthorName { get; set; }
        public decimal Ratings { get; set; }

     }
}

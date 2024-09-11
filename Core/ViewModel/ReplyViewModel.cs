using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int TopicId { get; set; }
        public string AuthorName { get; set; }
    }
}

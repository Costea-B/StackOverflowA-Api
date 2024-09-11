using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CreateReplyRequest
    {
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int? ParentReplyId { get; set; }
    }
}

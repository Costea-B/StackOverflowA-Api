using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CreateTopicRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public int UserId { get; set; }
    }
}

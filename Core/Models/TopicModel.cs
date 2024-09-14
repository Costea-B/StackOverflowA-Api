using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
     public class TopicModel
     {
          public int Id { get; set; }
          public string? Title { get; set; }
          public string? Description { get; set; }
          public DateTime Datecreate { get; set; }
          public IList<string> Tags { get; set; } = new List<string>();
          public UserModel? User { get; set; }
          public int UserId { get; set; }
     }
}

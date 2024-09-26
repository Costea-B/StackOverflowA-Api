using Core.Models;

namespace Core.DbModels
{
     public class TopicDbTables
     {
          public int Id {get; set; }
          public string Title { get; set; } = string.Empty;
          public string Description { get; set; } = string.Empty;
        public DateTime Datecreate { get; set; }

          public IList<string> Tags { get; set; } = new List<string>();

        public UsersDbTables? User { get; set; } 
          public int UserId { get; set; }
          public ICollection<ReplyDbTables> Replies { get; set; } = new List<ReplyDbTables>();
    }
}

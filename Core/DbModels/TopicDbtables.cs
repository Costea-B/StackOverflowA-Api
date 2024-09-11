using Core.Models;

namespace Core.DbModels
{
     public class TopicDbTables
     {
          public int Id {get; set; }
          public string? Title { get; set; }
          public string? Description { get; set; }
          public DateTime Datecreate { get; set; }

          public IList<string> Tags { get; set; } = new List<string>();

          public UserModel? User { get; set; }
          public int UserId { get; set; }
        public ICollection<ReplyDbTables> Replies { get; set; }
    }
}

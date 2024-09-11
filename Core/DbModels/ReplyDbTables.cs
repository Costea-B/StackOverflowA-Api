using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DbModels
{
    public class ReplyDbTables
    {
        public ReplyDbTables(int authorId, string description, int topicId)
        {
            AuthorId = authorId;
            Description = description;
            TopicId = topicId;
            CreatedAt = DateTime.Now;
        }

        public ReplyDbTables(int authorId, string description, int topicId, int? parentReplyId)
        {
            AuthorId = authorId;
            Description = description;
            TopicId = topicId;
            ParentReplyId = parentReplyId;
            CreatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public UsersDbTables Author { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int TopicId { get; set; }
        public TopicDbTables Topic { get; set; }


        // Experimente
        public int? ParentReplyId { get; set; }
        public ReplyDbTables ParentReply { get; set; }
        public ICollection<ReplyDbTables> ChildReplies { get; set; }
    }
}

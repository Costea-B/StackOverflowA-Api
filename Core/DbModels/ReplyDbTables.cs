﻿using System;
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
        }

        /*public ReplyDbTables(int authorId, string description, DateTime createdAt, int topicId)
        {
            AuthorId = authorId;
            Description = description;
            CreatedAt = createdAt;
            TopicId = topicId;
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int TopicId { get; set; }
        public TopicDbTables Topic { get; set; }
        public UsersDbTables Users { get; set; }
    }
}
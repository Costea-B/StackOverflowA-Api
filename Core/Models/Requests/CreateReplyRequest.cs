﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Requests
{
    public class CreateReplyRequest
    {
         public CreateReplyRequest(int authorId, string description, int topicId)
         {
              AuthorId = authorId;
              Description = description;
              TopicId = topicId;
         }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
    }
}

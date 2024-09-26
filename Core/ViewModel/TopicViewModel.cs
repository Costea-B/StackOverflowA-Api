﻿using Core.DbModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class TopicViewModel
    {
        public TopicViewModel(TopicDbTables topic)
        {
            Id = topic.Id;
            Title = topic.Title;
            Description = topic.Description ?? string.Empty;
            Datecreate = topic.Datecreate;
            Tags = topic.Tags;
            UserId = topic.UserId;
            User = new UserModel(topic.User.Id, topic.User.Name, topic.User.Email, topic.User.Password);
            ResponseCount = topic.Replies.Count;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public DateTime Datecreate { get; set; }
        public IList<string> Tags { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int ResponseCount { get; set; }
    }
}

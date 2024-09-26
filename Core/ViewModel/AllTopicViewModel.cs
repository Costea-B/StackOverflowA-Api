using Core.DbModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
     public class AllTopicViewModel
     {
          public AllTopicViewModel(TopicDbTables topic)
          {
               Id = topic.Id;
               Title = topic.Title;
               Description = topic.Description ?? string.Empty;
               Datecreate = topic.Datecreate;
               Tags = topic.Tags;
               ResponseCount = topic.Replies.Count;
          }

          public int Id { get; set; }
          public string? Title { get; set; }
          public string Description { get; set; }
          public DateTime Datecreate { get; set; }
          public IList<string> Tags { get; set; }
          public int ResponseCount { get; set; }
     }
}

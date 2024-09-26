using Core.DbModels;
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
          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public DateTime Datecreate { get; set; }
          public IList<string> Tags { get; set; }
          public UserViewModel User { get; set; }
          public int UserId { get; set; }
          public List<ReplyViewModel> Replies { get; set; }
    }
}



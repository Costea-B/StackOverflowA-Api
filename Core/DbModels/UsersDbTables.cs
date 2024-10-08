﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.DbModels
{
     public class UsersDbTables
     {
          public UsersDbTables(string name, string password, string email)
          {
               Name = name;
               Password = password;
               Email = email;
          }

          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          public string Name { get; set; }

          [Required]
          public string Password { get; set; }

          [Required]
          public string Email { get; set; }
          public ICollection<ReplyDbTables> Replies { get; set; }
        [JsonIgnore]
        public ICollection<TopicDbTables> Topics { get; set; } = new List<TopicDbTables>();

    }
}

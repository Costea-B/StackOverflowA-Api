using Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class AppDbContext
    {
        public DbSet<UsersDbTables> UserDbTables { get; set; }
        public DbSet<TopicDbTables> TopicDbTables { get; set; }
        public DbSet<ReplyDbTables> ReplyDbTables { get; set; }
    }
}

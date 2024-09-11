using Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<UsersDbTables> UserDbTables { get; set; }
        public DbSet<TopicDbTables> TopicDbTables { get; set; }
        public DbSet<ReplyDbTables> ReplyDbTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurarea relațiilor între entități (ex. Topic - Reply)
            modelBuilder.Entity<ReplyDbTables>()
                .HasOne(r => r.Topic)
                .WithMany(t => t.Replies)
                .HasForeignKey(r => r.TopicId);

            modelBuilder.Entity<ReplyDbTables>()
                .HasOne(r => r.Author)
                .WithMany(u => u.Replies)
                .HasForeignKey(r => r.AuthorId);
        }
    }
}

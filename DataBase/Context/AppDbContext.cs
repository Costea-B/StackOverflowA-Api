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
            
               //Pentru Dima 
            // Configurarea relației între Reply și Topic
            modelBuilder.Entity<ReplyDbTables>()           //tabelul care va crea relatile 
                .HasOne(r => r.Topic)          //Crearea relatiei unu la mai multe un raspuns e la un topic
                .WithMany(t => t.Replies)      //un topic poate avea mai multe raspunsuri     
                .HasForeignKey(r => r.TopicId) // cheaia straina pentru relatii poate exista HashKey() cheie primara din acelasi tabel 
                .OnDelete(DeleteBehavior.Cascade);         // Stergerea unui topic va sterge toate raspunsurile acestuia 

            //Configurarea relatiei intre User si Topic
            modelBuilder.Entity<TopicDbTables>()
                .HasOne(t => t.User) //Asta cand un topic este creat de un singur user
                .WithMany(u => u.Topics) //Aici cand un user poate crea mai multe topicuri
                .HasForeignKey(t => t.UserId) 
                .OnDelete(DeleteBehavior.Restrict); //Aici nu poti sterge un user daca el are create topicuri

        
            // Configurarea relației între Reply și User
            modelBuilder.Entity<ReplyDbTables>()
                 .HasOne(r => r.Author)
                 .WithMany(u => u.Replies)
                 .HasForeignKey(r => r.AuthorId)
                 // .OnDelete(DeleteBehavior.Restrict);  // nu pot sterge un user daca are raspunsuri 
                 .OnDelete(DeleteBehavior.SetNull); // la stergea user raspunsurile o sa ramana orfane fara useru care la creat
               
            
            //Configurarea intre Topic si Replies
            modelBuilder.Entity<TopicDbTables>()
                .HasMany(t => t.Replies)  // Un topic poate avea mai multe replies
                .WithOne(r => r.Topic)  // Fiecare reply aparține unui singur topic
                .HasForeignKey(r => r.TopicId)  // Cheia străină în Reply este TopicId
                .OnDelete(DeleteBehavior.Cascade);  // La ștergerea unui topic, se șterg toate replies asociate

            // Convertirea de rating pentur db
            modelBuilder.Entity<ReplyDbTables>()
                .Property(m => m.Ratings)
                .HasColumnType("NVARCHAR(MAX)");

            base.OnModelCreating(modelBuilder);
          }
    }
}
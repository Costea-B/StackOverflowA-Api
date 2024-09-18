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

        
            // Configurarea relației între Reply și User
            modelBuilder.Entity<ReplyDbTables>()
                 .HasOne(r => r.Author)
                 .WithMany(u => u.Replies)
                 .HasForeignKey(r => r.AuthorId)
                 // .OnDelete(DeleteBehavior.Restrict);  // nu pot sterge un user daca are raspunsuri 
                 .OnDelete(DeleteBehavior.SetNull); // la stergea user raspunsurile o sa ramana orfane fara useru care la creat

            //Configurari pentru reply de reply Ion Poate)
            modelBuilder.Entity<ReplyDbTables>()
                 .HasOne(r => r.ParentReply)                // Un Reply poate avea un Reply părinte
                 .WithMany(r => r.ChildReplies)             // Un Reply poate avea mai multe Replies copil
                 .HasForeignKey(r => r.ParentReplyId)
                 .OnDelete(DeleteBehavior.Cascade);                    // La ștergerea unui Reply părinte, șterge și toate Replies copil

               
            base.OnModelCreating(modelBuilder);
        }
    }
}
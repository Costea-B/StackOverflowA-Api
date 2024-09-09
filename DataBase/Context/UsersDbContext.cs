using Core.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context
{
     public class UsersDbContext: DbContext
     {
          public UsersDbContext(DbContextOptions options) : base(options){}

          public  DbSet<UsersDbTables> UserDbTables { get; set; }


     }
}

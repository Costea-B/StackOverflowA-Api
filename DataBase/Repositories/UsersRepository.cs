using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DbModels;
using Core.Models;
using DataBase.Context;

namespace DataBase.Repositories
{
     public class UsersRepository
     {

          private readonly UsersDbContext _dbContext;

          
          public UsersRepository(UsersDbContext dbContext)
          {
               _dbContext = dbContext;
          }
          public UserModel CreateUser(UserModel user)
          {
              

               UsersDbTables newUser = new UsersDbTables()
               {
                    Id = user.Id,
                    Name = user.Name,
                    Email = "Joric",
                    Password = "Joric"
                    
               };
               _dbContext.Users.Add(newUser);
               _dbContext.SaveChanges();
               

               return user;
          }
     }
}

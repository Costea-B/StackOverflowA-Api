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

               var newUser = new UsersDbTables(user.Name, user.Password, user.Email);
               
               _dbContext.UserDbTables.Add(newUser);
               _dbContext.SaveChanges();
               

               return user;
          }

          public UserModel LoginUsers(UserModel user)
          {
               var auth =  _dbContext.UserDbTables.FirstOrDefault(x => x.Name == user.Name );
               if (auth != null)
               {
                    var users = new UserModel(auth.Id, auth.Name, auth.Email, auth.Password);
                    return users;
               }
               return null;
          }
     }
}

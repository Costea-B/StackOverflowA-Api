using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using DataBase.Repositories;


// IUsersService = Services => Abstractions
// UserModel class = CORE
// UsersService (Create, Get by ID, login) / Services => Implementations
// UsersDbContext DataBase / Contexts
// IUsersDbContext - optional / Database => Abstractions
// UsersController - create , login (JWT) | API => Controllers




namespace Services.Users
{
     public interface IUserService
     {
          UserModel create(int age);
     }
     public class UsersService: IUserService
     {
          public UsersService(UsersRepository usersRepository) { }
          public UserModel create(int age)
          {
               var user = new UserModel();
               user.Name = age.ToString();
               user.Id = age;

               // TODO : DB LOGIC
               return user;
          }
     }

     public class UsersService2 : IUserService
     {
          public UsersService2(UsersRepository usersRepository) { }
          public UserModel create(int age)
          {
               var user = new UserModel();
               user.Name = (age + 3).ToString();
               user.Id = age + 2;

               // TODO : DB LOGIC
               return user;
          }
     }
}

using Core.DbModels;
using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
using DataBase.Abstraction;
using DataBase.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class UsersRepository : IUserRepository
     {
          private readonly AppDbContext _dbContext;
          
          public UsersRepository(AppDbContext dbContext)
          {
               _dbContext = dbContext;
          }

          public async Task<UserRegRequest> Register(UserRegRequest user)
          {
               var newUser = new UsersDbTables(user.FullName, user.Password, user.Email);

            await _dbContext.UserDbTables.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            
            return new UserRegRequest { FullName = newUser.Name };
          }

          public async Task<UserModel> LoginUsers(UserLoginRequest user)
          {
               var auth = await _dbContext.UserDbTables.FirstOrDefaultAsync(x => x.Email == user.Email );
               if (auth == null)
               {
                     throw new Exception("Invalid credential");
               }

               return new UserModel(auth.Id, auth.Name, auth.Email, auth.Password);
          }

          public async Task<UserViewModel> GetUser(int id)
          {
               var user =  await _dbContext.UserDbTables.FirstOrDefaultAsync(u => u.Id == id);
               return new UserViewModel(user.Id, user.Email, user.Name);
          }

          public async Task<UsersDbTables> GetDataForUserChange(int id)
          {
               var users = await _dbContext.UserDbTables.FirstOrDefaultAsync(u => u.Id == id);
               if (users == null)
               {
                    throw new Exception("Pasol Nahui");
               }
               return users;
          }

          public async Task ChangeUserData(UserModel user)
          {
               var users = await _dbContext.UserDbTables.FirstOrDefaultAsync(u => u.Id == user.Id);
               if (users != null)
               {
                    users.Name = user.Name;
                    users.Email = user.Email;
                    users.Password = user.Password;
                    await _dbContext.SaveChangesAsync();
               }
               else
               {
                    throw new Exception("nu ma zaibi");
               }
          }
     }
}

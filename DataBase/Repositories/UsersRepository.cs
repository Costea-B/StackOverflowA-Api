using Core.DbModels;
using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
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

          public async Task<RegisterViewModel> Register(UserRegRequest user)
          {
               var newUser = new UsersDbTables(user.FullName, user.Password, user.Email);

            await _dbContext.UserDbTables.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return new RegisterViewModel { Id = newUser.Id};
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

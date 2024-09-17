using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
using DataBase.Repositories;
using Services.Abstractions;


// IUsersService = Services => Abstractions
// UserModel class = CORE
// UsersService (Create, Get by ID, login) / Services => Implementations
// UsersDbContext DataBase / Contexts
// IUsersDbContext - optional / Database => Abstractions
// UsersController - create , login (JWT) | API => Controllers




namespace Services.Users
{
     public class UsersServices : IUsersServices
     {
          private readonly UsersRepository _usersRepository;


         
          public UsersServices(UsersRepository usersRepository )
          {
               _usersRepository = usersRepository;
               
               
          }
          public Task<RegisterViewModel> Register(UserRegRequest user)
          {
               
               var userLogin = _usersRepository.Register(user);
               return userLogin;
          }

          public UserModel LoginUser(UserModel user)
          {
               var userLogin = _usersRepository.LoginUsers(user);
               return userLogin;
          }
     }

}

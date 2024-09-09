using Core.Models;
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
          private readonly IPasswordHash _passwordHash;
          private readonly JwtProvid _jwtProvid;

          public UsersServices(UsersRepository usersRepository, IPasswordHash passwordHash, JwtProvid jwtProvid)
          {
               _usersRepository = usersRepository;
               _passwordHash = passwordHash;
               _jwtProvid = jwtProvid;
          }
          public UserModel CreateNewUsers(UserModel user)
          {
               user.Password = _passwordHash.Generate(user.Password);
               var userLogin = _usersRepository.CreateUser(user);
               return userLogin;
          }

          public UserModel LoginUsers(UserModel user)
          {
               var userLogin = _usersRepository.LoginUsers(user);

               var result = _passwordHash.Verify(password: user.Password, hashPassword: userLogin.Password);
               if (result)
               {
                    _jwtProvid.GenerateJwtToken(userLogin);
               }

               return userLogin;
          }
     }

  //   public class UsersService2 : IUsersServices
  //   {
  //        private readonly UsersRepository _usersRepository;
  //
  //        public UsersService2(UsersRepository usersRepository)
  //        {
  //             _usersRepository = usersRepository;
  //        }
  //        public UserModel LoginUser(UserModel users)
  //        {
  //             var user = new UserModel();
  //             user.Name = (users.Id + 3).ToString();
  //             user.Id = users.Id + 2;
  //
  //
  //             var userss = _usersRepository.CreateUser(user);
  //
  //              TODO : DB LOGIC
  //             return user;
  //        }
  //   }


}

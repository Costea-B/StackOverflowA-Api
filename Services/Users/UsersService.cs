﻿using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;
using DataBase.Abstraction;
using DataBase.Repositories;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Services.Abstractions;
using UserModel = Core.Models.UserModel;


namespace Services.Users
{
     public class UsersServices : IUsersServices
     {
          private readonly IUserRepository _usersRepository;
          private readonly JwtProvid _jtw;
          private readonly IPasswordHash _passwordHash;

         
          public UsersServices(IUserRepository usersRepository, JwtProvid jwt ,  IPasswordHash passwordHash)
          {
               _usersRepository = usersRepository;
               _jtw=jwt;
               _passwordHash = passwordHash;
          }

          public Task<UserRegRequest> Register(UserRegRequest user)
          {
               user.Password = _passwordHash.Generate(user.Password);
               var userLogin = _usersRepository.Register(user);
               return userLogin;
          }

          public async Task ChangeUserData(ChangeUserDataViewModel user)
          {

               var currentUser = await _usersRepository.GetDataForUserChange(user.Id);

               var resul = _passwordHash.Verify(password: user.CurrentPassword, currentUser.Password );
               if (resul)
               {
                    user.NewPassword = _passwordHash.Generate(user.NewPassword);
                    await _usersRepository.ChangeUserData(new UserModel(user.Id, user.Name, user.Email, user.NewPassword));
               }
               else
               {
                    throw new Exception("Invalid password");
               }
          }

          public async Task<string> Login(UserLoginRequest user)
          {
               var users = await _usersRepository.LoginUsers(user);
               var result = _passwordHash.Verify(password: user.Password, hashPassword: users.Password);

               if (!result)
               {
                    throw new Exception("baran)");
               }

               return _jtw.GenerateJwtToken(users);
          }
          
     }

}

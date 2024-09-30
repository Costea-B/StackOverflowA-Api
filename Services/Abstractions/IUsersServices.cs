using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;

namespace Services.Abstractions
{
    public interface IUsersServices
     {
          Task<string> Login(UserLoginRequest users);
          Task<UserRegRequest> Register(UserRegRequest user);
          Task ChangeUserData(ChangeUserDataViewModel user);
     }
}

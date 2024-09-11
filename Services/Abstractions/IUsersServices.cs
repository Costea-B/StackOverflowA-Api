using Core.Models;
using Core.Models.Requests;
using Core.ViewModel;

namespace Services.Abstractions
{
    public interface IUsersServices
     {
          UserModel LoginUser(UserModel users);
          Task<RegisterViewModel> Register(UserRegRequest user);
     }
}

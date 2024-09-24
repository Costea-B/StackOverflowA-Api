using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ViewModel;

namespace Services.Abstractions
{
     public interface ICurrentUserServices
     {
          Task<UserViewModel> GetUser();
     }
}

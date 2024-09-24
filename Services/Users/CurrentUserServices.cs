using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Services.Abstractions;

namespace Services.Users
{
     public class CurrentUserServices: ICurrentUserServices
     {
          private readonly IHttpContextAccessor _httpContextAccessor;

          public CurrentUserServices(IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
          }

          public string UserName => _httpContextAccessor.HttpContext?.Items["User"]?.ToString();

          public int UserId
          {
               get
               {
                    var userIdClaim = _httpContextAccessor.HttpContext?.Items["userId"]?.ToString();
                    return Int32.Parse(userIdClaim);
               }
          }
     }
}

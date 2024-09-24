using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
     public class ICurrentUserServices
     {
          public string UserName { get; }
          public int UserId { get; }
     }
}

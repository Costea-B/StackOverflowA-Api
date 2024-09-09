using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
     public interface IPasswordHash
     {
          string Generate(string password);
          bool Verify(string password, string hashPassword);
     }
}

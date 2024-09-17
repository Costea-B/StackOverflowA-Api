
using Services.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace Services.Users
{
     public class PasswordHash: IPasswordHash
     {
          public string Generate(string password)
          {
               return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
          }

          public bool Verify(string password, string hashPassword)
          {
               return BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword);
          }

          public string HashJwt(string password)
          {
               using (var md5 = MD5.Create())
               {
                    var inputBytes = Encoding.UTF8.GetBytes(password);
                    var hashBytes = md5.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
               }
          }
     }
}

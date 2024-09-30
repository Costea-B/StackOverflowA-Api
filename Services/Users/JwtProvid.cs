using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Services.Users
{
     public class JwtProvid
     {
          private readonly PasswordHash _hash;

          public JwtProvid(PasswordHash hash)
          {
               _hash=hash;
          }


          public string GenerateJwtToken(UserModel user)
          {
               var encryp = _hash.HashJwt(user.Name);
               var key = Encoding.UTF8.GetBytes(encryp);

               Claim[] claims = 
               {
                    new Claim("userName", user.Name),
                    new Claim("userId", user.Id.ToString())
               };

               

               var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
               );

               var token = new JwtSecurityToken(
                    claims:claims,
                    signingCredentials:signingCredentials,
                    expires: DateTime.UtcNow.AddHours(48)
                    );

               var takenValue = new JwtSecurityTokenHandler().WriteToken(token);

               return takenValue;
          }
          
     }
}

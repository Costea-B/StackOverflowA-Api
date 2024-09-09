using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Models;
using Microsoft.IdentityModel.Tokens;

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
               Claim[] claims = 
               {
                    new Claim("userName", user.Name),
                    new Claim("userId", user.Id.ToString())
               };

               var key = _hash.Generate(user.Name);
               var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256
               );

               var token = new JwtSecurityToken(
                    claims:claims,
                    signingCredentials:signingCredentials,
                    expires: DateTime.UtcNow.AddMinutes(30)
                    );

               var takenValue = new JwtSecurityTokenHandler().WriteToken(token);

               return takenValue;
          }
     }
}

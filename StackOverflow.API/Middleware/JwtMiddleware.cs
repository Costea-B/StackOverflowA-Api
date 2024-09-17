using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Services.Abstractions;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly IServiceScopeFactory _scopeFactory;
    public JwtMiddleware(RequestDelegate next, IConfiguration configuration, IServiceScopeFactory scopeFactory)
    {
        _next = next;
        _configuration = configuration;
        _scopeFactory = scopeFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Cookies.ContainsKey("JwtToken"))
        {
             var endpoint = context.GetEndpoint();
             if (endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null)
             {
                  await _next(context);
                  return;
             }

               var token = context.Request.Cookies["JwtToken"];

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                     using (var scopo = _scopeFactory.CreateScope())
                     {
                          var hash = scopo.ServiceProvider.GetRequiredService<IPasswordHash>();

                          var tokenHandler = new JwtSecurityTokenHandler();
                          var jwtToken = tokenHandler.ReadJwtToken(token);
                          var userName = jwtToken.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;

                          if (userName == null)
                          {
                               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                               await context.Response.WriteAsync("Invalid Token: Missing userName claim");
                               return;
                          }

                          var encryp = hash.HashJwt(userName);
                          var key = Encoding.UTF8.GetBytes(encryp);

                              var validationParameters = new TokenValidationParameters
                          {
                               ValidateIssuer = false,
                               ValidateAudience = false,
                               ValidateLifetime = true,
                               ValidateIssuerSigningKey = true,
                               IssuerSigningKey = new SymmetricSecurityKey(key)
                          };

                          var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);


                          context.Items["User"] = claimsPrincipal;
                         }
                }
                catch(Exception ex) 
                {
                    
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync($"Invalid Token {ex.Message}");
                    return;
                }
            }
        }

       
        await _next(context);
    }
}
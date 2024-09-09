using DataBase.Context;
using DataBase.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<PasswordHash>();
builder.Services.AddScoped<IPasswordHash, PasswordHash>();
builder.Services.AddScoped<JwtProvid>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();



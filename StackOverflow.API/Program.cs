using DataBase.Abstraction;
using DataBase.Context;
using DataBase.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Topic;
using Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options
     .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IReplyService, ReplyServices>();
builder.Services.AddScoped<IReplyRepository, ReplyRepository>();
builder.Services.AddScoped<PasswordHash>();
builder.Services.AddScoped<IPasswordHash, PasswordHash>();
builder.Services.AddScoped<JwtProvid>();

builder.Services.AddCors(option =>
{
     option.AddPolicy("Policy", builder =>
     {
          builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
     });
});



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseCors("Policy");

app.UseRouting();

app.UseAuthentication();  
app.UseAuthorization();   

app.UseMiddleware<JwtMiddleware>(); 

app.MapControllers();



app.Run();



using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserApi.Abstract;
using UserApi.Business.Abstract;
using UserApi.Business.Concrete;
using UserApi.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserApi.Database.UserDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("AppContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


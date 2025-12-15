using gym.Application.Interfaces;
using gym.Application.Services;
using gym.Domain.Entities;
using gym.Domain.Interfaces;
using gym.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controllers (IMPORTANT)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();

// Add DB injection:
builder.Services.AddInfrastructure(builder.Configuration);

// User:
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Branch:
builder.Services.AddScoped<IRepository<Branch>, BranchRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


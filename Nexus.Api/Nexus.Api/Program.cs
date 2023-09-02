using Nexus.Api.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-NexusDb-6DBD6C81-F941-40D0-AAF9-E2011A44A862;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDb>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddDbContext<CompanyDb>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddDbContext<ProjectDb>(opt => opt.UseSqlServer(connectionString));

// Service Injection
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IProjectService, ProjectService>();

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

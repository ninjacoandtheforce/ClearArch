using CleanArch.Application;
using CleanArch.Application.Abstractions;
using CleanArch.Application.CommandHandlers;
using CleanArch.Application.Commands;
using CleanArch.Application.Queries;
using CleanArch.Application.QueryHandlers;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure;
using CleanArch.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure();
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(cs));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCommand<>).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetByIdQuery<>).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetByIdQueryHandler<>).Assembly));
builder.Services.AddTransient<IRequestHandler<CreateCommand<Person>, Person>, CreateCommandHandler<Person>>();
builder.Services.AddTransient<IRequestHandler<GetByIdQuery<Person>, Person>, GetByIdQueryHandler<Person>>();


//builder.Services.AddMediatR(typeof(CreateCommand<>).Assembly, typeof(Program).Assembly);

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

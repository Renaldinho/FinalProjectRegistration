using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlite("Data source= ../Infrastructure/Database/db.db"));

Application.DependencyResolvement.DependencyResolverService.RegisterApplicationLayer(builder.Services);
Infrastructure.DependencyResolvement.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);

var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<PostStudentDTO, Student>();
}).CreateMapper();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton(mapper);

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
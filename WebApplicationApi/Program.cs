using ApplicationServices.Automapper;
using ApplicationServices.DTOs.Models;
using FluentValidation.AspNetCore;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApplicationApi.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjeccion();
builder.Services.AddServicesContext(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjeccionMapper();
builder.Services.AddMvc()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddValidator>())
              .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

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

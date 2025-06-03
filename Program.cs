using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Endpoints;
using PollinatorBE.Interfaces;
using PollinatorBE.Repositories;
using PollinatorBE.Services;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
// Add configuration to read from user secrets when in development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var connectionString = builder.Configuration.GetConnectionString("PollinatorBEDbConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string 'PollinatorBEDbConnection' is missing or empty.");
}
builder.Services.AddDbContext<PollinatorBEDbContext>(options => options.UseNpgsql(connectionString));

// Here we are registering the services and repositories with the DI container.
// The DI container will inject the services and repositories into the endpoints (controllers).
// DI (Dependency Injection) is a design pattern that allows us to develop loosely coupled code.
// Loosely coupled code is code where the classes and objects are independent of each other.
// This makes the code easier to maintain, test, and extend.
builder.Services.AddScoped<IGardenPlantServices, GardenPlantServices>();
builder.Services.AddScoped<IGardenPlantRepository, GardenPlantRepository>();

builder.Services.AddScoped<IGardenServices, GardenServices>();
builder.Services.AddScoped<IGardenRepository, GardenRepository>();

builder.Services.AddScoped<IPlantServices, PlantServices>();
builder.Services.AddScoped<IPlantRepository, PlantRepository>();

builder.Services.AddScoped<IPollinatorServices,PollinatorServices>();
builder.Services.AddScoped<IPollinatorRepository, PollinatorRepository>();

builder.Services.AddScoped<IUserProfileServices, UserProfileServices>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Here we are calling the extension method MapWeatherEndpoints() to map the weather endpoints.
// The extension method is defined in the WeatherForecastEndpoints class.
// The extension method is a static method that extends the IEndpointRouteBuilder interface.
// The extension method is used to group related endpoints together.
// An extension method is a special kind of static method that is used to add new functionality to existing types.
// A static method is a method that belongs to the class itself, not to instances of the class.
app.MapUserProfileEndpoints();
app.MapPollinatorEndpoints();
app.MapPlantEndpoints();
app.MapGardenEndpoints();
app.MapGardenPlantEndpoints();

app.Run();

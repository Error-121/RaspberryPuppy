using RaspberryPuppy;
using RaspberryPuppy.EFDbContext;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PuppyDbContext>();
builder.Services.AddTransient<GenericPuppyRepo<Personality>, GenericPuppyRepo<Personality>>();
builder.Services.AddTransient<GenericPuppyRepo<TripData>, GenericPuppyRepo<TripData>>();

builder.Services.AddControllers();

//var connectionString = builder.Configuration.GetConnectionString("RaspberryPuppyDB");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using RaspberryPuppy;
using RaspberryPuppy.EFDbContext;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<>(new RaspberryPuppyRepo());

builder.Services.AddControllers();

//var connectionString = builder.Configuration.GetConnectionString("RaspberryPuppyDB");
builder.Services.AddDbContext<PuppyDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using RaspberryPuppy;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<RaspberryPuppyRepo>(new RaspberryPuppyRepo());
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

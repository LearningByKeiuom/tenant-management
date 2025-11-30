using Infrastructure;
using Application;
using WebAPI_v2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Services.GetJwtSettings(builder.Configuration));
builder.Services.AddApplicationServices();

var app = builder.Build();

// Database Seeder
await app.Services.AddDatabaseInitializerAsync();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseInfrastructure();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();
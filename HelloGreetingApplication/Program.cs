using BusinessLayerBL.Interface;
using BusinessLayerBL.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using NLog.Extensions.Logging;
using RepositoryLayer.Context;
using RepositoryLayerRL.Interface;
using RepositoryLayer.Service;



var builder = WebApplication.CreateBuilder(args);
// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository and Service Layers
builder.Services.AddScoped<IGreetingRL, GreetingRL>();  // Repository
builder.Services.AddScoped<IGreetingBL, GreetingBL>();  // Business Logic


var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Info("Application is starting...");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Logging.ClearProviders();
builder.Host.UseNLog();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
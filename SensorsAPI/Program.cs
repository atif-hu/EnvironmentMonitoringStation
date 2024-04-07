using Microsoft.EntityFrameworkCore;
using MonitoringStationAPI.Database;
using SensorsAPI.Controllers;
using SensorsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//// Add DbContext and specify the SQLite connection string
//builder.Services.AddDbContext<MonitoringStationDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<TemperatureSensorController>(); // Register TemperatureSensorController
builder.Services.AddHostedService<TemperatureReadingService>();

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

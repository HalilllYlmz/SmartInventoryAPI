using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Hubs;
using SmartInventoryAPI.Services;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.WithOrigins("http://localhost:4200", "http://localhost:5173") 
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()); 
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddAuthorization(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddHostedService<SensorBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization(); 

app.MapControllers();

app.MapHub<SensorHub>("/sensorHub");

app.Run();
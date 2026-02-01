using Microsoft.AspNetCore.SignalR;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Hubs;
using SmartInventoryAPI.Models;

namespace SmartInventoryAPI.Services
{
    public class SensorBackgroundService : BackgroundService
    {
        private readonly IHubContext<SensorHub> _hubContext;
        private readonly IServiceScopeFactory _scopeFactory;

        public SensorBackgroundService(IHubContext<SensorHub> hubContext, IServiceScopeFactory scopeFactory)
        {
            _hubContext = hubContext;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // BURADAN SİLDİM

            while (!stoppingToken.IsCancellationRequested)
            {
                // BURAYA EKLEDİM: Her döngüde yeni sayı üretilsin
                var temperature = Random.Shared.Next(20, 101); 

                // 1. Statik değişkeni güncelle (Yeni gelenler bunu görecek)
                SensorHub.LastTemperature = temperature;

                // 2. Canlı olanlara gönder
                await _hubContext.Clients.All.SendAsync("ReceiveTemperature", temperature, stoppingToken);

                // 3. Kritik seviye kontrolü
                if (temperature > 80)
                {
                    await LogAlarmToDatabase(temperature);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task LogAlarmToDatabase(int temperature)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var log = new AlarmLog
                {
                    Temperature = temperature,
                    Message = $"Dikkat! Sıcaklık eşik değerini aştı: {temperature}°C",
                    LogDate = DateTime.UtcNow
                };

                dbContext.AlarmLogs.Add(log);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
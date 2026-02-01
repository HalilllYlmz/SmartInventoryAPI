using Microsoft.AspNetCore.SignalR;

namespace SmartInventoryAPI.Hubs
{
    public class SensorHub : Hub
    {
        public static int LastTemperature = 0;

        public async Task GetCurrentTemperature()
        {
            // İsteyen kişiye (Caller) son değeri hemen gönder.
            await Clients.Caller.SendAsync("ReceiveTemperature", LastTemperature);
        }
    
    }
}
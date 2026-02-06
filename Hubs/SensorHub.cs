using Microsoft.AspNetCore.SignalR;

namespace SmartInventoryAPI.Hubs
{
    public class SensorHub : Hub
    {
        public static int LastTemperature = 0;

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveTemperature", LastTemperature);
            
            await base.OnConnectedAsync();
        }
    
    }
}
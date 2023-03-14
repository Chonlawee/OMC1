using Microsoft.AspNetCore.SignalR;

namespace OMC.Hubs
{
    public class Queuehub :Hub
    {
        public async Task UpdateCountdown(int position,int orderId)
        {
            await Clients.All.SendAsync("UpdateCountdown", position,orderId);
        }
    }
}

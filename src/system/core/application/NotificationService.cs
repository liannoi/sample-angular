using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application
{
    public class NotificationService : Hub<INotificationService>
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.ReceiveNotification(message);
        }
    }
}
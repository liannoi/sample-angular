using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Update
{
    public class ManufacturerUpdated : INotification
    {
        public int ManufacturerId { get; set; }

        private class Handler : INotificationHandler<ManufacturerUpdated>
        {
            private readonly IHubContext<NotificationService, INotificationService> _notificationService;

            public Handler(IHubContext<NotificationService, INotificationService> notificationService)
            {
                _notificationService = notificationService;
            }

            public async Task Handle(ManufacturerUpdated notification, CancellationToken cancellationToken)
            {
                await _notificationService.Clients.All.ReceiveNotification(notification.ManufacturerId.ToString());
            }
        }
    }
}
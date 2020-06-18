using System.Threading.Tasks;

namespace SampleAngular.Application.Common.Interfaces
{
    public interface INotificationService
    {
        public Task ReceiveNotification(string message);
    }
}
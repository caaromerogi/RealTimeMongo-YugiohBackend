using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHub.Hub
{
    public interface IMongoNotificationClient
    {
        Task NotificationReceivedAsync(Card card, string mongoOperationType);
    }
}

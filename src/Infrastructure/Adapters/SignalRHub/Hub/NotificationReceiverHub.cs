using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHub.Hub
{
    public class NotificationReceiverHub : Hub<IMongoNotificationClient>
    {

    }
}

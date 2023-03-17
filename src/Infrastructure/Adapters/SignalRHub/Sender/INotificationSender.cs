using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHub.Sender
{
    public interface INotificationSender
    {
        public Task ConnectToStream();
    }
}

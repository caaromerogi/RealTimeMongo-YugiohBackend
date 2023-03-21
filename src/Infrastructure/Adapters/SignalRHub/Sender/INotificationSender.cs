﻿using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;

namespace SignalRHub.Sender
{
    public interface INotificationSender : IAsyncObserver<CardNotification>
    {
        //public Task ConnectToStream();
    }
}

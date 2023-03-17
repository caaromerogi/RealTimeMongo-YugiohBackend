using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;
using UseCases.Stream;

namespace SignalRHub.Sender
{
    public class NotificationSender : INotificationSender
    {
        //Sender
        private readonly IHubContext<NotificationReceiverHub, IMongoNotificationClient> _hubContext;
        //UseCase
        private readonly IUpdateDatabaseUseCase _updateDatabaseUseCase;

        public NotificationSender(IHubContext<NotificationReceiverHub, IMongoNotificationClient> hubContext, IUpdateDatabaseUseCase updateDatabaseUseCase)
        {
            _hubContext = hubContext;
            _updateDatabaseUseCase = updateDatabaseUseCase;
        }

        public async Task ConnectToStream()
        {
            CardModifiedDTO card = await _updateDatabaseUseCase.UpdateDatabaseAsync();
            await _hubContext.Clients.All.NotificationReceivedAsync(card.AsModelEntity(), card.MongoOperationType);
        }
    }
}

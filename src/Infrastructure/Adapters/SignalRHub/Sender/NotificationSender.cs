using Microsoft.AspNetCore.SignalR;
using Model.Entity;
using Newtonsoft.Json.Linq;
using Orleans.Streams;
using SignalRHub.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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


        public async Task OnNextAsync(CardNotification value, StreamSequenceToken token = null)
        {
            CardModifiedDTO card = await _updateDatabaseUseCase.UpdateDatabaseAsync(value);
            Console.WriteLine($"The card with id {card.Id} was {card.MongoOperationType}d");
            await _hubContext.Clients.All.NotificationReceivedAsync(card.AsModelEntity(), card.MongoOperationType);
        }

        public async Task OnCompletedAsync()
        {

            Console.WriteLine("Completed");
        }

        public async Task OnErrorAsync(Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
        


    }
}

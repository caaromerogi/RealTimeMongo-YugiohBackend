using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;
using UseCases.Gateways;

namespace UseCases.Stream
{
    public class UpdateDatabaseUseCase : IUpdateDatabaseUseCase
    {
        private readonly IChangeStreamMongo _streamMongo;
        private readonly ICardRepository _cardRepository;

        public UpdateDatabaseUseCase(IChangeStreamMongo streamMongo, ICardRepository cardRepository)
        {
            _streamMongo = streamMongo;
            _cardRepository = cardRepository;
        }

        public async Task<CardModifiedDTO> UpdateDatabaseAsync()
        {
            CardNotification notification = await _streamMongo.ReceiveDocumentChanged();

            if (notification.MongoOperationType.Equals("delete"))
            {
                return new()
                {
                    Id = notification.Id,
                    MongoOperationType= notification.MongoOperationType
                };
            }

            Card card = await _cardRepository.GetCardById(notification.Id);

            return new()
            {
                Id = card.Id,
                Name = card.Name,
                InInventory = card.InInventory,
                Type = card.Type,
                FrameType = card.FrameType,
                Desc = card.Desc,
                Atk = card.Atk,
                Def = card.Def,
                Level = card.Level,
                Race = card.Race,
                Attribute = card.Attribute,
                CardImages = card.CardImages,
                CardPrices = card.CardPrices,
                CurrentOwner = card.CurrentOwner,
                LastOwners = card.LastOwners,
                MongoOperationType = notification.MongoOperationType
            };

        }
    }
}

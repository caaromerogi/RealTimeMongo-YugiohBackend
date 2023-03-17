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

        public Task<CardModifiedDTO> UpdateDatabaseAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateways;

namespace UseCases.UseCases
{
    public class GetAllCardsUseCase : IGetAllCardsUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetAllCardsUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _cardRepository.GetAllCards();
        }
    }
}

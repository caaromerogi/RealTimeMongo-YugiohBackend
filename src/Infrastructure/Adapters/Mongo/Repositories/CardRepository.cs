using Model.Entity;
using Mongo.Context;
using Mongo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateways;

namespace Mongo.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<CardBsonEntity> _cardsCollection;

        public CardRepository(IContext context)
        {
            _cardsCollection = context.Cards;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            IAsyncCursor<CardBsonEntity> cursor = await _cardsCollection.FindAsync(Builders<CardBsonEntity>.Filter.Empty);
            
            return cursor.ToEnumerable().Select(c => c.AsDomainEntity()).ToList(); 
        }

        public async Task<Card> GetCardById(int id)
        {
            IAsyncCursor<CardBsonEntity> cardBson = await _cardsCollection.FindAsync(Builders<CardBsonEntity>.Filter.Eq(c => c.Id, id));
            CardBsonEntity card = await cardBson.FirstOrDefaultAsync();
            return card.AsDomainEntity();
        }
    }
}

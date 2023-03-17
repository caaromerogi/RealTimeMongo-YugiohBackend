using Mongo.Context;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UseCases.DTO;
using UseCases.Gateways;

namespace Mongo.Streams
{
    public class ChangeStreamMongo : IChangeStreamMongo
    {
        private readonly IMongoCollection<CardBsonEntity> _cardsCollection;

        public ChangeStreamMongo(IContext context)
        {
            _cardsCollection = context.Cards;
        }

        public async Task<CardNotification> ReceiveDocumentChanged()
        {
            ChangeStreamOptions options = new () { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            //The operationType can be one of the following: insert, update, replace, delete, invalidate
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<CardBsonEntity>>().Match("{ operationType: { $in: [ 'replace', 'insert', 'update', 'delete' ] } }");
            var changeStream = (await _cardsCollection.WatchAsync(pipeline,options)).ToEnumerable().GetEnumerator();
            changeStream.MoveNext();
            ChangeStreamDocument<CardBsonEntity> next = changeStream.Current;

            CardNotification notification = new()
            {
                Id = Int32.Parse(Regex.Match(next.DocumentKey.ToString(), @"\d+").Value),
                MongoOperationType = next.OperationType.ToString()
            };

            return notification;
        }
    }
}

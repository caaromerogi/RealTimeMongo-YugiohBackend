using Mongo.Context;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UseCases.DTO;

namespace Mongo.Streams
{
    public class ChangeStreamMongo : IChangeStreamMongo
    {
        private readonly IMongoCollection<CardBsonEntity> _cardsCollection;

        public ChangeStreamMongo(IContext context)
        {
            _cardsCollection = context.Cards;
        }

        public async Task<StreamSubscriptionHandle<CardNotification>> SubscribeAsync(IAsyncObserver<CardNotification> observer)
        {
            ChangeStreamOptions options = new() { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            //The operationType can be one of the following: insert, update, replace, delete, invalidate
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<CardBsonEntity>>().Match("{ operationType: { $in: [ 'replace', 'insert', 'update', 'delete' ] } }");
            var changeStream = (await _cardsCollection.WatchAsync(pipeline, options)).ToEnumerable().GetEnumerator();
            changeStream.MoveNext();
            ChangeStreamDocument<CardBsonEntity> next = changeStream.Current;
            Console.WriteLine(next.OperationType.ToString());
            int id = Int32.Parse(Regex.Match(next.DocumentKey.ToString(), @"\d+").Value);
            await observer.OnNextAsync(
                new CardNotification()
                {
                    Id = (int)next.FullDocument.Id!,
                    MongoOperationType = next.OperationType.ToString(),

                });
            return await this.SubscribeAsync(observer);

        }

        public async Task<StreamSubscriptionHandle<CardNotification>> SubscribeAsync(IAsyncObserver<CardNotification> observer, StreamSequenceToken token, StreamFilterPredicate filterFunc = null, object filterData = null)
        {
            ChangeStreamOptions options = new() { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            //The operationType can be one of the following: insert, update, replace, delete, invalidate
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<CardBsonEntity>>().Match("{ operationType: { $in: [ 'replace', 'insert', 'update', 'delete' ] } }");
            var changeStream = (await _cardsCollection.WatchAsync(pipeline, options)).ToEnumerable().GetEnumerator();
            changeStream.MoveNext();
            ChangeStreamDocument<CardBsonEntity> next = changeStream.Current;
            Console.WriteLine(next.OperationType.ToString());
            int id = Int32.Parse(Regex.Match(next.DocumentKey.ToString(), @"\d+").Value);
            await observer.OnNextAsync(
                new CardNotification()
                {
                    Id = (int)next.FullDocument.Id!,
                    MongoOperationType = next.OperationType.ToString(),

                });
            return await this.SubscribeAsync(observer);
        }
    }
}

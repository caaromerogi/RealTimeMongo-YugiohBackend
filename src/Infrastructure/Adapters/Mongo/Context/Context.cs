using Mongo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Context
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context(string connectionString, string databaseName)
        {
            MongoClient _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<CardBsonEntity> Users => _database.GetCollection<CardBsonEntity>("Cards");
    }
}

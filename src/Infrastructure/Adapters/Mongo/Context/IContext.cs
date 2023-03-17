using Mongo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Context
{
    public interface IContext
    {
        public IMongoCollection<CardBsonEntity> Cards { get; }
    }
}

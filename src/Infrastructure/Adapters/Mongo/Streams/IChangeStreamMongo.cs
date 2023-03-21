using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;

namespace Mongo.Streams
{
    public interface IChangeStreamMongo : IAsyncObservable<CardNotification>
    {

    }
}

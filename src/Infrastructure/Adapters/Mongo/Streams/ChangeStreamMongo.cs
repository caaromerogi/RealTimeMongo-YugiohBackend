using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateways;

namespace Mongo.Streams
{
    public class ChangeStreamMongo : IChangeStreamMongo
    {
        public Task<string> ReceiveDocumentChanged()
        {
            throw new NotImplementedException();
        }
    }
}

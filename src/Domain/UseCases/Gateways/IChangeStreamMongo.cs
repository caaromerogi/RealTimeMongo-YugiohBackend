using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateways
{
    public interface IChangeStreamMongo
    {
        //Retorna el id y el tipo de operacion
        public Task<string> ReceiveDocumentChanged();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DatabaseHelper
{
    public interface IDatabaseMigration
    {
        public Task ReadCards();
    }
}

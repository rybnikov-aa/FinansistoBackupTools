using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class TransactionCollection : EntityCollection<Transaction>
    {
        internal TransactionCollection()
            : base()
        {
        }

        internal TransactionCollection(IEnumerable<Transaction> collection)
            : base(collection)
        {
        }
    }
}

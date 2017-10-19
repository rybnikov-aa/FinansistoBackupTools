using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class CurrencyCollection : EntityCollection<Currency>
    {
        internal CurrencyCollection()
            : base()
        {
        }

        internal CurrencyCollection(IEnumerable<Currency> collection)
            : base(collection)
        {
        }
    }
}

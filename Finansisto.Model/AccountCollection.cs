using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class AccountCollection : EntityCollection<Account>
    {
        internal AccountCollection()
            : base()
        {
        }

        internal AccountCollection(IEnumerable<Account> collection)
            : base(collection)
        {
        }
    }
}

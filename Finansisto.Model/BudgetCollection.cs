using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class BudgetCollection : EntityCollection<Budget>
    {
        internal BudgetCollection()
            : base()
        {
        }

        internal BudgetCollection(IEnumerable<Budget> collection)
            : base(collection)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class ProjectCollection : EntityCollection<Project>
    {
        internal ProjectCollection()
            : base()
        {
        }

        internal ProjectCollection(IEnumerable<Project> collection)
            : base(collection)
        {
        }
    }
}

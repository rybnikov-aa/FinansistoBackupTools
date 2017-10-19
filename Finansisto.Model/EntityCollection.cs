using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public abstract class EntityCollection<T> : ObservableCollection<T>
        where T : Entity, new()
    {
        public T Get(int id)
        {
            return this.FirstOrDefault(e => id.Equals(e.Id));
        }

        protected EntityCollection()
            : base()
        {
        }
        
        protected EntityCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }
    }
}

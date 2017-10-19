using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class CategoryCollection : EntityCollection<Category>
    {
        internal CategoryCollection()
            : base()
        {
        }

        internal CategoryCollection(IEnumerable<Category> collection)
            : base(collection)
        {
        }

        public CategoryCollection FindAllParentsOf(Category category)
        {
            return new CategoryCollection(from Category c in this where c.Id > 0 && c.Left < category.Left && c.Right > category.Right orderby c.Left select c);
        }
    }
}

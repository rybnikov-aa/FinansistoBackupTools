using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class Project : Entity
    {
        public bool Active { get; private set; }

        protected override void InitializeCore(DataRow sourceRow)
        {
            Active = GetBoolean(sourceRow, "is_active");
        }
    }
}

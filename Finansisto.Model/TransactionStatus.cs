using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model.Properties;

namespace Finansisto.Model
{
    public class TransactionStatus : EntityEnum
    {
        private TransactionStatus(string value, string name)
            : base(value, name)
        {
        }

        #region Статические члены

        public static TransactionStatus Restored { get { return _restored; } }
        public static TransactionStatus Pending { get { return _pending; } }
        public static TransactionStatus Unreconciled { get { return _unreconciled; } }
        public static TransactionStatus Cleared { get { return _cleared; } }
        public static TransactionStatus Reconciled { get { return _reconciled; } }

        private static TransactionStatus _restored = new TransactionStatus("RS", Resources.TransactionStatusRestored);
        private static TransactionStatus _pending = new TransactionStatus("PN", Resources.TransactionStatusPending);
        private static TransactionStatus _unreconciled = new TransactionStatus("UR", Resources.TransactionStatusUnreconciled);
        private static TransactionStatus _cleared = new TransactionStatus("CL", Resources.TransactionStatusCleared);
        private static TransactionStatus _reconciled = new TransactionStatus("RC", Resources.TransactionStatusReconciled);

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model.Properties;

namespace Finansisto.Model
{
    public class PaymentSystem : EntityEnum
    {
        private PaymentSystem(string value, string name)
            : base(value, name)
        {
        }

        #region Статические члены

        public static PaymentSystem Visa { get { return _visa; } }
        public static PaymentSystem VisaElectron { get { return _visaElectron; } }
        public static PaymentSystem MasterCard { get { return _masterCard; } }
        public static PaymentSystem Maestro { get { return _maestro; } }
        public static PaymentSystem Amex { get { return _amex; } }
        public static PaymentSystem Jcb { get { return _jcb; } }
        public static PaymentSystem Diners { get { return _diners; } }
        public static PaymentSystem Discover { get { return _discover; } }
        public static PaymentSystem Nets { get { return _nets; } }
        public static PaymentSystem UnionPay { get { return _unionPay; } }

        private static readonly PaymentSystem _visa = new PaymentSystem("VISA", Resources.PaymentSystemVisa);
        private static readonly PaymentSystem _visaElectron = new PaymentSystem("VISA_ELECTRON", Resources.PaymentSystemVisaElectron);
        private static readonly PaymentSystem _masterCard = new PaymentSystem("MASTERCARD", Resources.PaymentSystemMasterCard);
        private static readonly PaymentSystem _maestro = new PaymentSystem("MAESTRO", Resources.PaymentSystemMaestro);
        private static readonly PaymentSystem _amex = new PaymentSystem("AMEX", Resources.PaymentSystemAmex);
        private static readonly PaymentSystem _jcb = new PaymentSystem("JCB", Resources.PaymentSystemJcb);
        private static readonly PaymentSystem _diners = new PaymentSystem("DINERS", Resources.PaymentSystemDiners);
        private static readonly PaymentSystem _discover = new PaymentSystem("DISCOVER", Resources.PaymentSystemDiscover);
        private static readonly PaymentSystem _nets = new PaymentSystem("NETS", Resources.PaymentSystemNets);
        private static readonly PaymentSystem _unionPay = new PaymentSystem("UNIONPAY", Resources.PaymentSystemUnionPay);
        
        #endregion
    }
}

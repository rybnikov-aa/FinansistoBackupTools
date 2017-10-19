using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model.Properties;

namespace Finansisto.Model
{
    public enum CardType { None, Debit, Credit }

    public class AccountType : EntityEnum
    {
        public bool HasIssuer { get; private set; }
        public bool HasNumber { get; private set; }
        public CardType CardType { get; private set; }

        private AccountType(string value, string name)
            : this(value, name, false, false)
        {
        }

        private AccountType(string value, string name, bool hasIssuer, bool hasNumber)
            : this(value, name, hasIssuer, hasNumber, CardType.None)
        {
        }

        private AccountType(string value, string name, bool hasIssuer, bool hasNumber, CardType cardType)
            : base(value, name)
        {
            HasIssuer = hasIssuer;
            HasNumber = hasNumber;
            CardType = cardType;
        }

        #region Статические члены

        public static AccountType Cash { get { return _cash; } }
        public static AccountType Bank { get { return _bank; } }
        public static AccountType DebitCard { get { return _debitCard; } }
        public static AccountType CreditCard { get { return _creditCard; } }
        public static AccountType PayPal { get { return _paypal; } }
        public static AccountType Asset { get { return _asset; } }
        public static AccountType Liability { get { return _liability; } }
        public static AccountType Other { get { return _other; } }

        private static AccountType _cash = new AccountType("CASH", Resources.AccountTypeCash, false, false);
        private static AccountType _bank = new AccountType("BANK", Resources.AccountTypeBank, true, true);
        private static AccountType _debitCard = new AccountType("DEBIT_CARD", Resources.AccountTypeDebitCard, true, true, CardType.Debit);
        private static AccountType _creditCard = new AccountType("CREDIT_CARD", Resources.AccountTypeCreditCard, true, true, CardType.Credit);
        private static AccountType _paypal = new AccountType("PAYPAL", Resources.AccountTypePayPal);
        private static AccountType _asset = new AccountType("ASSET", Resources.AccountTypeAsset);
        private static AccountType _liability = new AccountType("LIABILITY", Resources.AccountTypeLiability);
        private static AccountType _other = new AccountType("OTHER", Resources.AccountTypeOther);

        #endregion
    }
}

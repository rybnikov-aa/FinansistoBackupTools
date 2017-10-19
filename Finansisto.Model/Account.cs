using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class Account : Entity
    {
        public DateTime? CreationDate { get; private set; }
        public DateTime? LastTransactionDate { get; private set; }
        public AccountType Type { get; private set; }
        public PaymentSystem CardPaymentSystem { get; private set; }
        public string Issuer { get; private set; }
        public string Number { get; private set; }
        public Money Total { get; private set; }
        public Money Limit { get; private set; }
        public int SortOrder { get; private set; }
        public bool Active { get; private set; }
        public bool Aggregate { get; private set; }
        public DateTime? CancellationDate { get; private set; }

        public bool IsOwnerOf(Transaction transaction)
        {
            return this.Equals(transaction.AccountFrom) || this.Equals(transaction.AccountTo);
        }

        public TransactionCollection GetTransactions()
        {
            return new TransactionCollection(from t in EntitySet.Transactions where IsOwnerOf(t) select t);
        }

        protected override void InitializeCore(DataRow sourceRow)
        {
            Currency currency = EntitySet.Currencies.Get(GetInt32(sourceRow, "currency_id", 0));

            CreationDate = GetDateTime(sourceRow, "creation_date");
            LastTransactionDate = GetDateTime(sourceRow, "last_transaction_date");
            Type = EntityEnum.Parse<AccountType>(GetString(sourceRow, "type"));
            CardPaymentSystem = EntityEnum.Parse<PaymentSystem>(GetString(sourceRow, "card_issuer"));
            Issuer = GetString(sourceRow, "issuer");
            Number = GetString(sourceRow, "number");
            Total = new Money(GetMoneyAmount(sourceRow, "total_amount", 0m), currency);
            Limit = new Money(GetMoneyAmount(sourceRow, "total_limit", 0m), currency);
            SortOrder = GetInt32(sourceRow, "sort_order", 0);
            Active = GetBoolean(sourceRow, "is_active");
            Aggregate = GetBoolean(sourceRow, "is_include_into_totals");
            CancellationDate = GetDateTime(sourceRow, "closing_day");
        }
    }
}

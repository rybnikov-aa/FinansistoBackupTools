using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class Transaction : Entity
    {
        private int _parentId;

        public Account AccountFrom { get; private set; }
        public Account AccountTo { get; private set; }
        public Category Category { get; private set; }
        public Project Project { get; private set; }
        public string Note { get; private set; }
        public decimal AmountFrom { get; private set; }
        public decimal AmountTo { get; private set; }
        public DateTime DateTime { get; private set; }
        public TransactionStatus Status { get; private set; }
        public Currency OriginalCurrency { get; private set; }
        public decimal OriginalAmount { get; private set; }
        public bool IsTemplate { get; private set; }
        public string TemplateName { get; private set; }

        public bool IsSplit => (Category?.IsSplit).GetValueOrDefault();
        public bool IsTransfer => AccountTo != null;

        public override string ToString()
        {
            return string.Format("{0:g} {1} ({2})", DateTime, Category, AmountFrom);
        }
        
        public Transaction FindParent() => EntitySet.Transactions.FirstOrDefault(t => t.Id == _parentId);
        public TransactionCollection FindChildren() => new TransactionCollection(EntitySet.Transactions.Where(t => t._parentId == Id));

        protected override void InitializeCore(DataRow sourceRow)
        {
            _parentId = GetInt32(sourceRow, "parent_id", 0);

            AccountFrom = EntitySet.Accounts.Get(GetInt32(sourceRow, "from_account_id", 0));
            AccountTo = EntitySet.Accounts.Get(GetInt32(sourceRow, "to_account_id", 0));
            Category = EntitySet.Categories.Get(GetInt32(sourceRow, "category_id", 0));
            Project = EntitySet.Projects.Get(GetInt32(sourceRow, "project_id", 0));
            Note = GetString(sourceRow, "note");
            AmountFrom = GetMoneyAmount(sourceRow, "from_amount", 0m);
            AmountTo = GetMoneyAmount(sourceRow, "to_amount", 0m);
            DateTime = GetDateTime(sourceRow, "datetime", DateTime.MinValue);
            Status = EntityEnum.Parse<TransactionStatus>(GetString(sourceRow, "status"));
            OriginalCurrency = EntitySet.Currencies.Get(GetInt32(sourceRow, "original_currency_id", 0));
            OriginalAmount = GetMoneyAmount(sourceRow, "original_from_amount", 0m);
            IsTemplate = GetBoolean(sourceRow, "is_template");
            TemplateName = GetString(sourceRow, "template_name");
        }
    }
}

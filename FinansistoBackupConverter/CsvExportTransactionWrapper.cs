using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model;

namespace FinansistoBackupConverter
{
    sealed class CsvExportTransactionWrapper
    {
        public string Id => string.Format("{0}", _transaction.Id);
        public string AccountFrom => string.Format("{0}", _transaction.AccountFrom);
        public string AccountTo => string.Format("{0}", _transaction.AccountTo);
        public string Category => string.Format("{0}", GetCategoryStringWithParents(_transaction.Category));
        public string Project => string.Format("{0}", _transaction.Project);
        public string Note => string.Format("{0}", _transaction.Note);
        public string AmountFrom => string.Format("{0}", _transaction.AmountFrom);
        public string AmountTo => string.Format("{0}", _transaction.AmountTo);
        public string DateTime => string.Format("{0}", _transaction.DateTime);
        public string Status => string.Format("{0}", _transaction.Status);
        public string CategoryType => string.Format("{0}", _transaction.Category?.Type);

        public CsvExportTransactionWrapper(Transaction transaction)
        {
            _transaction = transaction;
        }

        private Transaction _transaction;

        private string GetCategoryStringWithParents(Category category)
        {
            if (category != null)
            {
                CategoryCollection parents = category.FindAllParents();
                return parents.Count > 0 ? string.Format("{0}:{1}", string.Join(":", parents.Select(p => p.Title)), category.Title) : category.Title;
            }
            return string.Empty;
        }
    }
}

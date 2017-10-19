using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public sealed class EntitySet
    {
        public CurrencyCollection Currencies { get { return _currencies == null ? _currencies = GetCurrencies() : _currencies; } }
        public CategoryCollection Categories { get { return _categories == null ? _categories = GetCategories() : _categories; } }
        public ProjectCollection Projects { get { return _projects == null ? _projects = GetProjects() : _projects; } }
        public AccountCollection Accounts { get { return _accounts == null ? _accounts = GetAccounts() : _accounts; } }
        public BudgetCollection Budgets { get { return _budgets == null ? _budgets = GetBudgets() : _budgets; } }
        public TransactionCollection Transactions { get { return _transactions == null ? _transactions = GetTransactions() : _transactions; } }
        public TransactionCollection Templates { get { return _templates == null ? _templates = GetTemplates() : _templates; } }

        internal EntitySet(DataSet dataSet)
        {
            _dataSet = dataSet;
        }

        internal T CreateEntity<T>(DataRow sourceRow)
            where T : Entity, new()
        {
            T entity = new T() { EntitySet = this };
            entity.Initialize(sourceRow);
            return entity;
        }

        private CurrencyCollection _currencies;
        private CategoryCollection _categories;
        private ProjectCollection _projects;
        private AccountCollection _accounts;
        private BudgetCollection _budgets;
        private TransactionCollection _transactions;
        private TransactionCollection _templates;

        private readonly DataSet _dataSet;

        private IEnumerable<T> GetEntities<T>(string tableName)
            where T : Entity, new()
        {
            return from DataRow r in _dataSet.Tables[tableName].Rows select CreateEntity<T>(r);
        }

        private CurrencyCollection GetCurrencies()
        {
            return new CurrencyCollection(GetEntities<Currency>("currency"));
        }

        private CategoryCollection GetCategories()
        {
            CategoryCollection col = new CategoryCollection();
            col.Add(Category.CreateSplit(this));
            foreach (var c in GetEntities<Category>("category"))
            {
                col.Add(c);
            }
            return col;
        }

        private ProjectCollection GetProjects()
        {
            return new ProjectCollection(GetEntities<Project>("project"));
        }

        private AccountCollection GetAccounts()
        {
            return new AccountCollection(GetEntities<Account>("account"));
        }

        private BudgetCollection GetBudgets()
        {
            return new BudgetCollection(GetEntities<Budget>("budget"));
        }

        private TransactionCollection GetTransactions()
        {
            return new TransactionCollection(GetEntities<Transaction>("transactions").Where(t => !t.IsTemplate));
        }

        private TransactionCollection GetTemplates()
        {
            return new TransactionCollection(GetEntities<Transaction>("transactions").Where(t => t.IsTemplate));
        }
    }
}

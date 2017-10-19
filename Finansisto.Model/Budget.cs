using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class Budget : Entity
    {
        public CategoryCollection Categories { get; private set; }
        public ProjectCollection Projects { get; private set; }
        public Currency Currency { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IncludeSubCategories { get; private set; }
        public bool IncludeIncome { get; private set; }
        public bool ProjectOrCategory { get; private set; }

        protected override void InitializeCore(DataRow dataRow)
        {
            Categories = GetCategories(GetString(dataRow, "category_id"));
            Projects = GetProjects(GetString(dataRow, "project_id"));
            Currency = EntitySet.Currencies.Get(GetInt32(dataRow, "currency_id", 0));
            Amount = GetMoneyAmount(dataRow, "amount", 0m);
            StartDate = GetDateTime(dataRow, "start_date", DateTime.MinValue);
            EndDate = GetDateTime(dataRow, "end_date", DateTime.MaxValue);
            IncludeSubCategories = GetBoolean(dataRow, "include_subcategories");
            IncludeIncome = GetBoolean(dataRow, "include_credit");
            ProjectOrCategory = GetBoolean(dataRow, "expanded");
        }

        private CategoryCollection GetCategories(string categoryString)
        {
            if (string.IsNullOrEmpty(categoryString))
            {
                return new CategoryCollection();
            }
            else
            {
                return new CategoryCollection(categoryString.Split(',').Select(cid => EntitySet.Categories.Get(int.Parse(cid))));
            }
        }

        private ProjectCollection GetProjects(string projectString)
        {
            if (string.IsNullOrEmpty(projectString))
            {
                return new ProjectCollection();
            }
            else
            {
                return new ProjectCollection(projectString.Split(',').Select(pid => EntitySet.Projects.Get(int.Parse(pid))));
            }
        }
    }
}
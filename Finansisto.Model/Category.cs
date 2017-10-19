using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public enum CategoryType
    {
        Expense,
        Income,
        Split
    }

    public class Category : Entity
    {
        public CategoryType Type { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }

        public bool IsUnknown => Id == 0;
        public bool IsSplit => Type == CategoryType.Split;

        public CategoryCollection FindAllParents() => EntitySet?.Categories?.FindAllParentsOf(this) ?? new CategoryCollection();

        protected override void InitializeCore(DataRow sourceRow)
        {
            Type = GetInt32(sourceRow, "type", 0) == 1 ? CategoryType.Income : CategoryType.Expense;
            Left = GetInt32(sourceRow, "left", 0);
            Right = GetInt32(sourceRow, "right", 0);
        }

        public Category() { }

        private Category(int id, string title) : base(id, title) { }

        #region Статические члены

        public static bool IsNullOrUnknown(Category category)
        {
            return category == null || category.IsUnknown;
        }

        internal static Category CreateSplit(EntitySet entitySet)
        {
            return new Category(-1, "[Сплит...]") { EntitySet = entitySet, Type = CategoryType.Split };
        }

        #endregion
    }
}

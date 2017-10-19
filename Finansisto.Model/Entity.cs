using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model.Properties;

namespace Finansisto.Model
{
    public abstract class Entity : IEquatable<Entity>
    {
        public EntitySet EntitySet { get; internal set; }
        public int Id { get; private set; }
        public string Title { get; private set; }

        public bool Equals(Entity other)
        {
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Title;
        }

        public Entity() { }

        internal Entity(int id, string title)
        {
            Id = id;
            Title = title;
        }

        internal void Initialize(DataRow sourceRow)
        {
            if (sourceRow == null)
            {
                throw new ArgumentNullException("sourceRow");
            }
            Id = GetId(sourceRow);
            Title = GetTitle(sourceRow);
            InitializeCore(sourceRow);
        }

        protected virtual int GetId(DataRow dataRow)
        {
            return GetInt32(dataRow, "_id", 0);
        }

        protected virtual string GetTitle(DataRow dataRow)
        {
            return GetString(dataRow, "title");
        }

        protected abstract void InitializeCore(DataRow sourceRow);

        #region Статические члены

        internal static string GetString(DataRow dataRow, string columnName)
        {
            return dataRow.Table.Columns.Contains(columnName) ? string.Format("{0}", dataRow[columnName]) : null;
        }

        internal static int? GetInt32(DataRow dataRow, string columnName)
        {
            int result;
            if (int.TryParse(GetString(dataRow, columnName), out result))
            {
                return result;
            }
            return null;
        }

        internal static int GetInt32(DataRow dataRow, string columnName, int defaultValue)
        {
            return GetInt32(dataRow, columnName).GetValueOrDefault(defaultValue);
        }

        internal static double? GetDouble(DataRow dataRow, string columnName)
        {
            double result;
            if (double.TryParse(GetString(dataRow, columnName), out result))
            {
                return result;
            }
            return null;
        }

        internal static double GetDouble(DataRow dataRow, string columnName, double defaultValue)
        {
            return GetDouble(dataRow, columnName).GetValueOrDefault(defaultValue);
        }

        internal static DateTime? GetDateTime(DataRow dataRow, string columnName)
        {
            double? milliseconds = GetDouble(dataRow, columnName);
            if (milliseconds.HasValue)
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(milliseconds.Value)).ToLocalTime();
            }
            return null;
        }

        internal static DateTime GetDateTime(DataRow dataRow, string columnName, DateTime defaultValue)
        {
            return GetDateTime(dataRow, columnName).GetValueOrDefault(defaultValue);
        }

        internal static decimal? GetMoneyAmount(DataRow dataRow, string columnName)
        {
            decimal result;
            if (decimal.TryParse(GetString(dataRow, columnName), out result))
            {
                return result / 100m;
            }
            return null;
        }

        internal static decimal GetMoneyAmount(DataRow dataRow, string columnName, decimal defaultValue)
        {
            return GetMoneyAmount(dataRow, columnName).GetValueOrDefault(defaultValue);
        }

        internal static bool GetBoolean(DataRow dataRow, string columnName)
        {
            return GetInt32(dataRow, columnName, 0) > 0;
        }

        #endregion
    }
}

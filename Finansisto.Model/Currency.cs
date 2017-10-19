using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public class Currency : Entity, IFormatProvider
    {
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public string SymbolFormat { get; private set; }
        public int DecimalDigits { get; private set; }
        public string DecimalSeparator { get; private set; }
        public string GroupSeparator { get; private set; }
        public bool IsDefault { get; private set; }

        public Money Convert(Money money)
        {
            if (this.Equals(money.Currency))
            {
                return money;
            }
            throw new NotImplementedException();
        }

        public string FormatMoney(decimal amount)
        {
            return amount.ToString("C", this);
        }

        public object GetFormat(Type formatType)
        {
            return GetNumberFormat().GetFormat(formatType);
        }

        protected override void InitializeCore(DataRow sourceRow)
        {
            Name = GetString(sourceRow, "name");
            Symbol = GetString(sourceRow, "symbol");
            SymbolFormat = GetString(sourceRow, "symbol_format", false, GetDefaultSymbolFormat());
            DecimalDigits = GetInt32(sourceRow, "decimals", 2);
            DecimalSeparator = GetString(sourceRow, "decimal_separator", true, _cultureFormat.NumberDecimalSeparator);
            GroupSeparator = GetString(sourceRow, "group_separator", true, _cultureFormat.NumberGroupSeparator);
            IsDefault = GetBoolean(sourceRow, "is_default");
        }

        private NumberFormatInfo _cultureFormat = CultureInfo.CurrentCulture.NumberFormat;

        private NumberFormatInfo GetNumberFormat()
        {
            return new NumberFormatInfo()
            {
                CurrencyDecimalSeparator = DecimalSeparator,
                CurrencyGroupSeparator = GroupSeparator,
                CurrencySymbol = Symbol,
                CurrencyDecimalDigits = DecimalDigits,
                CurrencyPositivePattern = GetPositivePattern(),
                CurrencyNegativePattern = GetNegativePattern()
            };
        }

        private int GetPositivePattern()
        {
            // 0"$n", 1"n$", 2"$ n", 3"n $"
            switch (SymbolFormat)
            {
                case "L": return 0;
                case "R": return 1;
                case "LS": return 2;
                case "RS": return 3;
                default:
                    return 3;
            }
        }

        private int GetNegativePattern()
        {
            // 0"($n)", 1"-$n", 2"$-n", 3"$n-", 4"(n$)", 5"-n$", 6"n-$", 7"n$-", 8"-n $", 9"-$ n", 10"n $-", 11"$ n-", 12"$ -n", 13"n- $", 14"($ n)", 15"(n $)"
            switch (SymbolFormat)
            {
                case "L": return 1;
                case "R": return 5;
                case "LS": return 9;
                case "RS": return 8;
                default:
                    return 8;
            }
        }

        private string GetString(DataRow sourceRow, string columnName, bool unquote, string valueIfNull)
        {
            string sourceString = GetString(sourceRow, columnName);
            if (sourceString == null)
            {
                return valueIfNull;
            }
            return unquote ? UnquoteString(sourceString) : sourceString;
        }

        private string UnquoteString(string s)
        {
            return s.Trim('\'');
        }

        #region

        public static Currency CurrentCultureCurrency { get { return GetCurrentCultureCurrency(); } }

        private static string GetDefaultSymbolFormat()
        {
            return "RS";
        }

        private static Currency GetCurrentCultureCurrency()
        {
            NumberFormatInfo nfi = CultureInfo.CurrentUICulture.NumberFormat;
            Currency currency = new Currency();
            currency.Symbol = nfi.CurrencySymbol;
            currency.SymbolFormat = GetDefaultSymbolFormat();
            currency.DecimalDigits = nfi.CurrencyDecimalDigits;
            currency.DecimalSeparator = nfi.CurrencyDecimalSeparator;
            currency.GroupSeparator = nfi.CurrencyGroupSeparator;
            currency.IsDefault = false;
            return currency;
        }

        #endregion
    }
}

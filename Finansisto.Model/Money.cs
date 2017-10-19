using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public struct Money : IFormattable, IEquatable<Money>, IComparable<Money>
    {
        public decimal Amount { get { return _amount; } }
        public Currency Currency { get { return GetCurrency(); } }

        public Money(decimal amount, Currency currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public Money ConvertTo(Currency currency)
        {
            return currency.Convert(this);
        }

        private decimal _amount;
        private Currency _currency;

        public override string ToString()
        {
            return ToString("C");
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format) || format == "C")
            {
                return Currency.FormatMoney(Amount);
            }
            else
            {
                return Amount.ToString(format, formatProvider);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((Money)obj);
        }

        public bool Equals(Money other)
        {
            if (other == null)
            {
                return false;
            }
            return Amount.Equals(other.Amount) && Currency.Equals(other.Currency);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }

        public int CompareTo(Money other)
        {
            return Amount.CompareTo(other.ConvertTo(Currency).Amount);
        }

        private Currency GetCurrency()
        {
            if (_currency == null)
            {
                _currency = Currency.CurrentCultureCurrency;
            }
            return _currency;
        }

        #region Операторы

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }

        public static bool operator >(Money m1, Money m2)
        {
            return m1.Amount > m2.ConvertTo(m1.Currency).Amount;
        }

        public static bool operator >=(Money m1, Money m2)
        {
            return (m1 > m2) || (m1 == m2);
        }

        public static bool operator <(Money m1, Money m2)
        {
            return !(m1 >= m2);
        }

        public static bool operator <=(Money m1, Money m2)
        {
            return (m1 < m2) || (m1 == m2);
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount, Currency.CurrentCultureCurrency);
        }

        public static explicit operator decimal(Money money)
        {
            return money.Amount;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model.Properties;

namespace Finansisto.Model
{
    public abstract class EntityEnum
    {
        public string Value { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        protected EntityEnum(string value, string name)
        {
            Value = value;
            Name = name;
        }

        #region Статические члены

        public static T Parse<T>(string value) where T : EntityEnum
        {
            foreach (var pi in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (typeof(T).Equals(pi.PropertyType))
                {
                    T enumValue = (T)pi.GetValue(null);
                    if (enumValue != default(T) && value.Equals(enumValue.Value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return enumValue;
                    }
                }
            }
            throw new InvalidEntityEnumValueException(string.Format(Resources.InvalidEntityEnumValue, value, typeof(T)));
        }

        #endregion
    }

    [Serializable]
    public class InvalidEntityEnumValueException : Exception
    {
        public InvalidEntityEnumValueException() { }
        public InvalidEntityEnumValueException(string message) : base(message) { }
        public InvalidEntityEnumValueException(string message, Exception inner) : base(message, inner) { }
        protected InvalidEntityEnumValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

using System;
using System.Globalization;

namespace Task2.Library
{
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Customer))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            string upperFormat = format.ToUpper(CultureInfo.InvariantCulture);
            if (!(upperFormat == "D" || upperFormat == "RN"))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            var customer = arg as Customer;

            switch (upperFormat)
            {
                case "RN":
                    return $"{customer.Revenue.ToString("N", CultureInfo.CreateSpecificCulture("en-US"))}, {customer.Name}";

                default:
                    return $"{customer.Name} | {customer.ContactPhone} | {customer.Revenue}";
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            if (arg != null)
            {
                return arg.ToString();
            }
            return String.Empty;
        }
    }
}

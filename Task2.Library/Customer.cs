using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public decimal Revenue { get; set; }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "D";
            }
            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "D":
                    return $"{Name.ToString(provider)}, {Revenue.ToString("N", provider)}, {ContactPhone}";

                case "P":
                    return ContactPhone.ToString(provider);

                case "N":
                    return Name.ToString(provider);

                case "R":
                    return Revenue.ToString(provider);

                case "NR":
                    return $"{Name.ToString(provider)}, {Revenue.ToString("N", provider)}";

                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}

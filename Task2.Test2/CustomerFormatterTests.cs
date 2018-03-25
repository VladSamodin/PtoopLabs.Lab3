using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task2.Test2
{
    [TestClass]
    public class CustomerFormatterTests
    {
        [TestMethod]
        public void Format_DFormatString_NameContactPhoneRevenueSeparatedByVerticalLine()
        {
            var customer = new Customer
            {
                Name = "Jeffrey Richter",
                ContactPhone = "+1 (425) 555-0100",
                Revenue = 1000000m
            };
            var fomatter = new CustomerFormatter();

            var expected = "Jeffrey Richter | +1 (425) 555-0100 | 1000000";
            var actual = string.Format(fomatter, "{0:D}", customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_RNFormatString_RevenueNameSeparatedByComma()
        {
            var customer = new Customer
            {
                Name = "Jeffrey Richter",
                ContactPhone = "+1 (425) 555-0100",
                Revenue = 1000000m
            };
            var fomatter = new CustomerFormatter();

            var expected = "1,000,000.00, Jeffrey Richter";
            var actual = string.Format(fomatter, "{0:RN}", customer);

            Assert.AreEqual(expected, actual);
        }
    }
}

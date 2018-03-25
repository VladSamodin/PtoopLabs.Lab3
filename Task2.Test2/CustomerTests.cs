using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Task2.Library;

namespace Task2.Test2
{
    [TestClass]
    public class CustomerTests
    {
        private Customer customer;

        [TestInitialize]
        public void Initializer()
        {
            customer = new Customer
            {
                Name = "Jeffrey Richter",
                ContactPhone = "+1 (425) 555-0100",
                Revenue = 1000000m
            };
        }


        [TestMethod]
        public void ToString_DFormatString_NameRevenueContactPhoneSeparatedByComma()
        {
            var expected = "Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100";
            var actual= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:D}", customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_PFormatString_ContactPhone()
        {
            var expected = "+1 (425) 555-0100";
            var actual = string.Format("{0:P}", customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_NFormatString_Name()
        {
            var expected = "Jeffrey Richter";
            var actual = string.Format("{0:N}", customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_RFormatString_Revenue()
        {
            var expected = "1000000";
            var actual = string.Format("{0:R}", customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_NRFormatString_NameRevenue()
        {
            var expected = "Jeffrey Richter, 1 000 000,00";
            var actual = string.Format("{0:NR}", customer);

            Assert.AreEqual(expected, actual);
        }
    }
}

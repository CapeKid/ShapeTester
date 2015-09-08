using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapeTesterServiceLayer.Tests
{
    [TestClass]
    public class NumberConverterTest
    {
        [TestMethod]
        public void NumberConverter_RegularIntegerString_ConvertsToCorrespondingInteger()
        {
            NumberConverter numberConverter = new NumberConverter();

            int result = numberConverter.ConvertNumber("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NumberConverter_Decimal_DoesSomething()
        {
            NumberConverter numberConverter = new NumberConverter();

            int result = 0;
            try
            {
                result = numberConverter.ConvertNumber("1.1");
            }
            catch (Exception exception)
            {
                Assert.AreEqual(0, result);
                Assert.AreEqual("shouldn't be decimal", exception.Message);
                throw;
            }
            

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        //This is why we should not mix Auditor and developer concerns!
        [ExpectedException(typeof(ArgumentNullException))]
        public void NumberConverter_Null_ThrowsArgumentNullException()
        {
            NumberConverter numberConverter = new NumberConverter();

            try
            {
                numberConverter.ConvertNumber(null);
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("Cannot convert \"null\" to a number." + Environment.NewLine + "Parameter name: number", exception.Message);
                throw;
            }
        }
    }
}

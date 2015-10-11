using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer.Tests
{
    [TestClass]
    public class DoubleRectangleTest
    {
        #region IntegerConstructor
        [TestMethod]
        public void IntegerConstructor_WidthIsPositive_XIsStartX()
        {
            DoubleRectangle rect = new DoubleRectangle(1, 2, 3, 4);

            Assert.AreEqual(1, rect.X);
        }

        [TestMethod]
        public void IntegerConstructor_WidthIsNegative_XIsStartXMinusWidth()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, -2, 1);

            Assert.AreEqual(2, rect.X);
        }

        public void IntegerConstructor_HeightIsPositive_YIsStartY()
        {
            DoubleRectangle rect = new DoubleRectangle(1, 2, 3, 4);

            Assert.AreEqual(2, rect.Y);
        }

        [TestMethod]
        public void IntegerConstructor_HeightIsNegative_YIsStartYMinusHeight()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, 2, -1);

            Assert.AreEqual(2, rect.Y);
        }

        [TestMethod]
        public void IntegerConstructor_WidthIsPositive_LeaveAsPositive()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, 2, 1);

            Assert.AreEqual(2, rect.Width);
        }

        [TestMethod]
        public void IntegerConstructor_WidthIsNegative_ConvertToPositive()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, -2, 1);

            Assert.AreEqual(2, rect.Width);
        }

        [TestMethod]
        public void IntegerConstructor_HeightIsPositive_LeaveAsPositive()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, 2, 1);

            Assert.AreEqual(1, rect.Height);
        }

        [TestMethod]
        public void IntegerConstructor_HeightIsNegative_ConvertToPositive()
        {
            DoubleRectangle rect = new DoubleRectangle(4, 3, 2, -1);

            Assert.AreEqual(1, rect.Height);
        }
        #endregion
    }
}

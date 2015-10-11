using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer.Tests
{
    [TestClass]
    public class DoubleRectangleFactoryTest
    {
        private IDoubleRectangleFactory DoubleRectangleFactory { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            DoubleRectangleFactory = new DoubleRectangleFactory();
        }

        #region IntegerConstructor
        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_WidthIsPositive_XIsStartX()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(1, 2, 3, 4);

            Assert.AreEqual(1, rect.X);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_WidthIsNegative_XIsStartXMinusWidth()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, -2, 1);

            Assert.AreEqual(2, rect.X);
        }

        public void CreateDoubleRectangleFromWebCoordinates_HeightIsPositive_YIsStartY()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(1, 2, 3, 4);

            Assert.AreEqual(2, rect.Y);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_HeightIsNegative_YIsStartYMinusHeight()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, 2, -1);

            Assert.AreEqual(2, rect.Y);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_WidthIsPositive_LeaveAsPositive()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, 2, 1);

            Assert.AreEqual(2, rect.Width);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_WidthIsNegative_ConvertToPositive()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, -2, 1);

            Assert.AreEqual(2, rect.Width);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_HeightIsPositive_LeaveAsPositive()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, 2, 1);

            Assert.AreEqual(1, rect.Height);
        }

        [TestMethod]
        public void CreateDoubleRectangleFromWebCoordinates_HeightIsNegative_ConvertToPositive()
        {
            DoubleRectangle rect = DoubleRectangleFactory.CreateDoubleRectangleFromWebCoordinates(4, 3, 2, -1);

            Assert.AreEqual(1, rect.Height);
        }
        #endregion
    }
}

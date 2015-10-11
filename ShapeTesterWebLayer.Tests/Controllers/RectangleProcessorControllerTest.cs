using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterWebLayer.Controllers;
using Rhino.Mocks;
using ShapeTesterWebLayer.ViewModel;
using ShapeTesterServiceLayer.SharedObjects;
using System.Web.Mvc;

namespace ShapeTesterWebLayer.Tests.Controllers
{
    [TestClass]
    public class RectangleProcessorControllerTest
    {
        private RectangleProcessorController _rectangleProcessorController;
        private IRectangleMathHelper _rectangleMathHelper;
        private IDoubleRectangleFactory _doubleRectangleFactory;

        [TestInitialize]
        public void Initialize()
        {
            _doubleRectangleFactory = MockRepository.GenerateMock<IDoubleRectangleFactory>();
            _rectangleMathHelper = MockRepository.GenerateMock<IRectangleMathHelper>();
            _rectangleProcessorController = new RectangleProcessorController(_rectangleMathHelper, _doubleRectangleFactory);
            
        }

        [TestMethod]
        public void TestAll_ValidInput_ReturnsValidJson()
        {
            Rectangle rect1 = new Rectangle()
            {
                StartX = 1,
                StartY = 2,
                Width = 3,
                Height = 4
            };
            Rectangle rect2 = new Rectangle()
            {
                StartX = 5,
                StartY = 6,
                Width = 7,
                Height = 8
            };

            DoubleRectangle doubleRect1 = new DoubleRectangle(1, 2, 3, 4);
            DoubleRectangle doubleRect2 = new DoubleRectangle(5, 6, 7, 8);

            _doubleRectangleFactory.Expect(x => x.CreateDoubleRectangleFromWebCoordinates(1, 2, 3, 4)).Return(doubleRect1);
            _doubleRectangleFactory.Expect(x => x.CreateDoubleRectangleFromWebCoordinates(5, 6, 7, 8)).Return(doubleRect1);

            _rectangleMathHelper.Expect(x => x.DoesEitherRectangleContainTheOther(doubleRect1, doubleRect2)).Return(true).IgnoreArguments();
            _rectangleMathHelper.Expect(x => x.DoesEitherRectangleOverlapTheOther(doubleRect1, doubleRect2)).Return(true).IgnoreArguments();
            _rectangleMathHelper.Expect(x => x.IsEitherRectangleAdjacentToTheOther(doubleRect1, doubleRect2)).Return(true).IgnoreArguments();

            var actionReturn = _rectangleProcessorController.TestAll(rect1, rect2);

            Assert.IsInstanceOfType(actionReturn, typeof(JsonResult));

            JsonResult jsonReturn = (JsonResult)actionReturn;
            Assert.AreEqual("{ isOverlap = True, isContain = True, isAdjacent = True }", jsonReturn.Data.ToString());

            _rectangleMathHelper.VerifyAllExpectations();
            _doubleRectangleFactory.VerifyAllExpectations();
        }
    }
}

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTesterWebLayer.Controllers;
using ShapeTesterServiceLayer;
using Rhino.Mocks;

namespace ShapeTesterWebLayer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //[TestMethod]
        //public void Index_OnLoad_ReturnsViewResult()
        //{
        //    // Arrange
        //    var adderMock = MockRepository.GenerateMock<IAdder>();
        //    HomeController controller = new HomeController(adderMock);

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void AddNumbers_TwoValidIntegers_ReturnsThoseTwoAddedTogether()
        {
            // Arrange
            var numberConverterFunctionality = new NumberConverter();
            var adderMock = new Adder(numberConverterFunctionality);
            var controller = new HomeController(adderMock);

            var testNumberOne = "1";
            var testNumberTwo = "2";
            
            // Act
            var result = controller.AddNumbers(testNumberOne, testNumberTwo) as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("The result is \"3\"", result.Content);
        }

        [TestMethod]
        public void AddNumbers_TwoValidIntegersAndMocking_ReturnsThoseTwoAddedTogether()
        {
            var adderMock = MockRepository.GenerateMock<IAdder>();
            var testNumberOne = "1";
            var testNumberTwo = "2";
            adderMock.Stub(x => x.AddTwoNumbers(testNumberOne, testNumberTwo)).Return("Some other answer");

            // Arrange
            var controller = new HomeController(adderMock);

            // Act
            var result = controller.AddNumbers(testNumberOne, testNumberTwo) as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Some other answer", result.Content);
            adderMock.VerifyAllExpectations();
        }
    }
}

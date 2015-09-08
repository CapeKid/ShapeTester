using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ShapeTesterServiceLayer.Tests
{
    [TestClass]
    public class AdderTest
    {
        [TestMethod]
        public void Add_TwoPositiveNumbers_CorrectResult()
        {
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();

            Adder adderFunctionality = new Adder(numberConverter);
            
            int result = adderFunctionality.Add(1, 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_TwoZeros_CorrectResult()
        {
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();
            Adder adderFunctionality = new Adder(numberConverter);

            int result = adderFunctionality.Add(0, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_NegativeAndPositiveNumber_CorrectResult()
        {
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();
            Adder adderFunctionality = new Adder(numberConverter);

            int result = adderFunctionality.Add(-1, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddTwoNumbers_TwoPositiveNumbers_CorrectResult()
        {
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();
            Adder adderFunctionality = new Adder(numberConverter);

            string numberOne = "1";
            string numberTwo = "1";
            numberConverter.Stub(x => x.ConvertNumber(numberOne)).Return(1);
            numberConverter.Stub(x => x.ConvertNumber(numberTwo)).Return(2);

            string result = adderFunctionality.AddTwoNumbers(numberOne, numberTwo);

            Assert.AreEqual("The result is \"2\"", result);
            numberConverter.VerifyAllExpectations();
        }

        [TestMethod]
        public void AddTwoNumbers_FirstNumberIsADecimalNumber_WhatDoWeDoHere()
        {
            //Let's finish this live! Do what do we want to do when presented with a decimal?
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();
            Adder adderFunctionality = new Adder(numberConverter);

            string numberOne = "1";
            string numberTwo = "1.1";
            numberConverter.Stub(x => x.ConvertNumber(numberOne)).Return(1);
            numberConverter.Stub(x => x.ConvertNumber(numberTwo)).Return(2);

            string result = adderFunctionality.AddTwoNumbers(numberOne, numberTwo);

            //Assert.AreEqual("The result is \"2\"", result);
            numberConverter.VerifyAllExpectations();
        }

        [TestMethod]
        public void AddTwoNumbers_SecondNumberIsADecimalNumber_WhatDoWeDoHere()
        {
            //Let's finish this live! Do what do we want to do when presented with a decimal?
            INumberConverter numberConverter = MockRepository.GenerateMock<INumberConverter>();
            Adder adderFunctionality = new Adder(numberConverter);

            string numberOne = "1";
            string numberTwo = "1.1";
            numberConverter.Stub(x => x.ConvertNumber(numberOne)).Return(1);
            numberConverter.Stub(x => x.ConvertNumber(numberTwo)).Return(2);

            string result = adderFunctionality.AddTwoNumbers(numberOne, numberTwo);

            //Assert.AreEqual("The result is \"2\"", result);
            numberConverter.VerifyAllExpectations();
        }

        //Does the above decimal test belong here?


        //Other tests go here or in the Number Converter?
    }
}

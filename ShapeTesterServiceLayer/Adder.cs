namespace ShapeTesterServiceLayer
{
    public class Adder : IAdder
    {
        public INumberConverter NumberConverterFunctionality { get; set; }

        public Adder(INumberConverter numberConverterFunctionality)
        {
            NumberConverterFunctionality = numberConverterFunctionality;
        }

        public int Add(int integerOne, int integerTwo)
        {
            return integerOne + integerTwo;
        }

        public string AddTwoNumbers(string numberOne, string numberTwo)
        {
            int integerOne = NumberConverterFunctionality.ConvertNumber(numberOne);
            int integerTwo = NumberConverterFunctionality.ConvertNumber(numberTwo);
            int result = Add(integerOne, integerTwo);

            return "The result is \"" + result + "\"";
        }
    }
}

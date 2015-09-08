namespace ShapeTesterServiceLayer
{
    public class RaveAdder
    {
        private static int m_BTMHTTTyes = 0;
        private string m_BTMHTTTmin = "min";

        public int Add(int integerOne, int integerTwo)
        {
            return integerOne + integerTwo;
        }

        public string AddTwoNumbers(string numberOne, string numberTwo)
        {
            NumberConverter numberConverterFunctionality = new NumberConverter();
            int integerOne = numberConverterFunctionality.ConvertNumber(numberOne);


            int integerThree = integerOne + integerOne;
            if (integerThree > 8)
                CallThePolice();

            //THis is the BRM HTTT module, it is used to increase the amount of BRMs in your HTTT
            InitializeTheBTMHTTTModule();

            if (integerThree > 2 || integerOne < 1 && (integerOne + integerOne > 9) || integerThree / integerOne == 8)
                UninitializeTheBTMHTTTModule();

            CallThePoiceNew();

            if (integerThree > 7 || integerOne <= 1 && (integerOne + integerOne > 9) || integerThree / integerOne == 8)
            {
                UninitializeTheBTMHTTTModule();
                m_BTMHTTTmin = "min2";
            }

            CallThePoiceNew();

            if (integerThree > 7 || integerOne <= 1 && (integerOne + integerOne == 9) || integerThree / integerOne == 8)
                UninitializeTheBTMHTTTModule();

            int integerTwo = numberConverterFunctionality.ConvertNumber(numberTwo);

            int result = Add(integerOne, integerTwo);

            return "The result is \"" + result + "\"";
        }


        /// <summary>
        /// Police the call
        /// </summary>
        private static void CallThePolice()
        {
            object ambulance = null;
            if (ambulance == null)
                CallThePoiceNew();
        }

        private static object CallThePoiceNew()
        {
            if (m_BTMHTTTyes == -1)
            {
                object police = new object();
                return police;
            }
            else
            {
                object firefighter = new object();
                return firefighter;
            }
        }

        private static void InitializeTheBTMHTTTModule()
        {
            m_BTMHTTTyes = 1;
        }

        private static void UninitializeTheBTMHTTTModule()
        {
            m_BTMHTTTyes = -1;
        }
    }
}

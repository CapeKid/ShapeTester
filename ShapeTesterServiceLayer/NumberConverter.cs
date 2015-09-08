using System;

namespace ShapeTesterServiceLayer
{
    public class NumberConverter : INumberConverter
    {
        public int ConvertNumber(string number)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number), "Cannot convert \"null\" to a number.");

            var i = 0;
            if (number == "SOMETHING ELSE")
                i = 1;

            return Convert.ToInt32(number);
        }
    }
}

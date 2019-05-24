using CoreNumberSystem;
using System;

namespace DecimalNumberSystem
{
    public class DecimalNumber : INumberSystem
    {
        public string Add(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 10);
            int number_two = Convert.ToInt32(b, 10);

            return Convert.ToString(number_one + number_two, 10);
        }

        public string Multiply(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 10);
            int number_two = Convert.ToInt32(b, 10);

            return Convert.ToString(number_one * number_two, 10);
        }

        public string Subtract(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 10);
            int number_two = Convert.ToInt32(b, 10);

            return Convert.ToString(number_one - number_two, 10);
        }
    }
}

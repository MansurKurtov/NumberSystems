﻿using CoreNumberSystem;
using System;

namespace BinaryNumberSystem
{
    public class BinaryNumber : INumberSystem
    {
        public string Add(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 2);
            int number_two = Convert.ToInt32(b, 2);

            return Convert.ToString(number_one + number_two, 2);
        }

        public string Multiply(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 2);
            int number_two = Convert.ToInt32(b, 2);

            return Convert.ToString(number_one * number_two, 2);
        }

        public string Subtract(string a, string b)
        {
            int number_one = Convert.ToInt32(a, 2);
            int number_two = Convert.ToInt32(b, 2);

            return Convert.ToString(number_one - number_two, 2);
        }
    }
}

using System;
using System.Text;

namespace binary_calculator
{
    public class TranslationIntoSystems
    {
        public static string ToBin(int number)
        {
            number = Math.Abs(number);
            StringBuilder result = new StringBuilder();
            if (number > 0)
                while (number > 0)
                {
                    result.Insert(0,number % 2);
                    number /= 2;
                }
            else result.Append("0");
            return result.ToString();
        }
        public static int ToDec(string str)
        {
            int result = 0;
            int k = 0;
            for(int i = str.Length - 1;i >= 0; i--)
            {
                result += (int)Math.Pow(2, k) * int.Parse(str[i].ToString());
                k++;
            }
            return result;
        }
    }
}
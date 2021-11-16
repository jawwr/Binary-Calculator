using System;
using System.Text;

namespace binary_calculator
{
    public class BinaryOperation
    {
        public static string Plus(string number1, string number2)
        {
            if (number2 == "1")
            {
                number2 = AddNonSignZero(number2, number1.Length);
            }
            StringBuilder result = new StringBuilder();
            int diff = 0;
            int i = number1.Length - 1;
            while (i >= 0 || diff != 0)
            {
                int first = default;
                int second = default;
                if (i != -1)
                { 
                    first = int.Parse(number1[i].ToString());
                    second = int.Parse(number2[i].ToString());
                }
                result.Insert(0,(first + second + diff) % 2);
                diff = (first + second + diff) > 1 
                    ? 1 
                    : 0;
                i--;
            }
            return result.ToString();
        }
        public static string Minus(string number1, string number2)
        {
            if (number2 == "1")
            {
                number2 = AddNonSignZero(number2, number1.Length);
            }
            StringBuilder result = new StringBuilder();
            int diff = 0;
            for(int i = number1.Length - 1;i >= 0;i--)
            {
                int first = int.Parse(number1[i].ToString());
                int second = int.Parse(number2[i].ToString());
                result.Insert(0,Math.Abs((first - second + diff) % 2));
                diff = (first - second + diff) < 0 
                    ? -1 
                    : 0;
            }
            return result.ToString();
        }
        public static string AddNonSignPoint(string str, int maxLength)
        {
            if(maxLength <= 8)
                while (str.Length < 8)
                    str = str.Insert(0,"1");
            else if(maxLength > 8 && maxLength <= 16)
                while (str.Length < 16)
                    str = str.Insert(0,"1");
            else if(maxLength > 16 && maxLength <= 32)
                while (str.Length < 32)
                    str = str.Insert(0,"1");
            return str;
        }
        public static string AddNonSignZero(string str, int maxLength)
        {
            if(maxLength <= 8)
                while (str.Length < 8)
                    str = str.Insert(0,"0");
            else if(maxLength > 8 && maxLength <= 16)
                while (str.Length < 16)
                    str = str.Insert(0,"0");
            else if(maxLength > 16 && maxLength <= 32)
                while (str.Length < 32)
                    str = str.Insert(0,"0");
            return str;
        }
        public static string Inverse(string num)
        {
            return num.Replace('0', ' ').Replace('1','0').Replace(' ','1');
        }
        public static (string, bool) Result(string first,string second, bool additional)
        {
            bool negative = false;
            string result = Plus(first, second);
            if(result.Length > Math.Max(first.Length,second.Length))
                result = result.Remove(0, 1);
            
            if (additional)
            {
                result = Minus(result, "1");
                result = Inverse(result);
                negative = true;
            }

            return (result, negative);
        }
    }
}
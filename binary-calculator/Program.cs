using System;
using System.Reflection;
using System.Text;

namespace binary_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine();

            string firstBin = string.Empty;
            string secondBin = string.Empty;
            bool additional = false;
            if (first < 0)
            {
                (firstBin, additional) = NegativeValue.Negative(first);
            }
            else
            {
                firstBin = ToBin(first);
                firstBin = BinaryOperation.AddNonSignZero(firstBin,firstBin.Length);
            }

            if (second < 0)
            {
                (secondBin, additional) = NegativeValue.Negative(second);
            }
            else
            {
                secondBin = ToBin(second);
                secondBin = BinaryOperation.AddNonSignZero(secondBin, secondBin.Length);
            }

            Console.WriteLine(firstBin);
            Console.WriteLine(secondBin);
            (string result,bool negative)= Result(firstBin, secondBin, additional);
            Console.WriteLine(result);
            int resultDec = negative
                ? -ToDec(result)
                : ToDec(result);
            Console.WriteLine(resultDec);
        }
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
        static int ToDec(string str)
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
        static (string, bool) Result(string first,string second, bool additional)
        {
            bool negative = false;
            string result = BinaryOperation.Plus(first, second);
            if(result.Length > Math.Max(first.Length,second.Length))
                result = result.Remove(0, 1);
            
            if (additional)
            {
                result = BinaryOperation.Minus(result, "1");
                result = BinaryOperation.Inverse(result);
                negative = true;
            }

            return (result, negative);
        }
    }
}
using System;
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
            
            string firstBin = ToBin(first);
            string secondBin = ToBin(second);
            
            firstBin = NonSignZero(firstBin, Math.Max(firstBin.Length, secondBin.Length));
            secondBin = NonSignZero(secondBin, firstBin.Length);
            
            if(first < 0)
                firstBin = NegativeValue(firstBin);
                
            if(second < 0)
                secondBin = NegativeValue(secondBin);

            Console.WriteLine();
            Console.WriteLine(firstBin);
            Console.WriteLine(secondBin);
            Console.WriteLine();
            string binResult;
            int decResult;
            bool isNegative = false;
            if (first >= 0 && second >= 0)
                binResult = BinPlus(firstBin, secondBin);
            else
                (binResult, isNegative) = NegativeResult(firstBin, secondBin);
            decResult = isNegative 
                ? -ToDec(binResult) 
                : ToDec(binResult);
            
            Console.WriteLine(binResult);
            Console.WriteLine(decResult);
        }
        static string ToBin(int number)
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
        static string BinPlus(string number1, string number2)
        {
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
        static string Inverse(string num)
        {
            return num.Replace('0', ' ').Replace('1','0').Replace(' ','1');
            // return inverseNumber;
        }

        static string NegativeValue(string number)
        {
            string negativeNumber = Inverse(number);
            // string point = "1";
            // while (number.Length > point.Length)
            //     point = point.Insert(0, "0");
            // string result = BinPlus(negativeNumber, point);
            return negativeNumber;
        }

        static (string, bool) NegativeResult(string first,string second)
        {
            bool negative = false;
            string result = BinPlus(first, second);
            // Console.WriteLine($"\t{result}");
            // if (result.Length > first.Length)
            result = result.Remove(0, 1);
            
            if (result[0] == '1')
            {
                result = Inverse(result);
                negative = true;
            }
            else
            {
                string point = "1";
                while (result.Length > point.Length)
                    point = point.Insert(0, "0");
                result = BinPlus(result, point);
                // StringBuilder resultMinus = new StringBuilder();
                // int diff = 0;
                // for (int i = result.Length - 1; i >= 0; i--)
                // {
                //     int firstnum = int.Parse(result[i].ToString());
                //     int secondnum = int.Parse(point[i].ToString());
                //     resultMinus.Insert(0, Math.Abs((firstnum - secondnum + diff) % 2));
                //     diff = (firstnum - secondnum + diff) < 0
                //         ? -1
                //         : 0;
                // }
            }

            return (result, negative);
        }
        static string NonSignZero(string str, int maxLength)
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
    }
}
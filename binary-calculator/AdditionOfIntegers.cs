using System;

namespace binary_calculator
{
    public class AdditionOfIntegers
    {
        public static void Additation()
        {
            Console.Clear();
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
                firstBin = TranslationIntoSystems.ToBin(first);
                firstBin = BinaryOperation.AddNonSignZero(firstBin,firstBin.Length);
            }

            if (second < 0)
            {
                (secondBin, additional) = NegativeValue.Negative(second);
            }
            else
            {
                secondBin = TranslationIntoSystems.ToBin(second);
                secondBin = BinaryOperation.AddNonSignZero(secondBin, secondBin.Length);
            }

            Console.WriteLine(firstBin);
            Console.WriteLine(secondBin);
            (string result,bool negative)= BinaryOperation.Result(firstBin, secondBin, additional);
            Console.WriteLine(result);
            int resultDec = negative
                ? -TranslationIntoSystems.ToDec(result)
                : TranslationIntoSystems.ToDec(result);
            Console.WriteLine(resultDec);
            Console.Read();
        }
    }
}
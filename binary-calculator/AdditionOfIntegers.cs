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

            string firstBin = TranslationIntoSystems.ToBin(first);
            string secondBin = TranslationIntoSystems.ToBin(second);
            bool additional = false;
            if (first < 0)
            {
                Console.WriteLine($"Так как первое число отрицательное, мы сначала переводим его в двоичную систему по модулю: {TranslationIntoSystems.ToBin(first)}");
                (firstBin, additional) = NegativeValue.AdditionalCode(first, Math.Max(firstBin.Length,secondBin.Length));
                Console.WriteLine($"Затем в полученной записи, мы инверсируем все биты и добавляем незначущую \"1\" в начало: {BinaryOperation.Minus(firstBin,"1")}");
                Console.WriteLine("Далее к полученной записи мы прибавляем \"1\"");
                Console.WriteLine($"Полученный результат: {firstBin}\n");
            }
            else
            {
                firstBin = TranslationIntoSystems.ToBin(first);
                firstBin = BinaryOperation.AddNonSignZero(firstBin, Math.Max(firstBin.Length,secondBin.Length));
                Console.WriteLine($"Так как первое число не отрицательное, мы просто переводим его в двоичную систему и добавляем незначущие нули: {firstBin}\n");
            }

            if (second < 0)
            {
                Console.WriteLine($"Так как второе отрицательное, мы сначала переводим его в двоичную систему по модулю: {TranslationIntoSystems.ToBin(second)}");
                (secondBin, additional) = NegativeValue.AdditionalCode(second,firstBin.Length);
                Console.WriteLine($"Затем в полученной записи, мы инверсируем все биты и добавляем незначущую \"1\" в начало: {BinaryOperation.Minus(secondBin,"1")}");
                Console.WriteLine("Далее к полученной записи мы прибавляем \"1\"");
                Console.WriteLine($"Полученный результат: {secondBin}\n");
            }
            else
            {
                secondBin = TranslationIntoSystems.ToBin(second);
                secondBin = BinaryOperation.AddNonSignZero(secondBin, Math.Max(firstBin.Length,secondBin.Length));
                Console.WriteLine($"Так как второе число не отрицательное, мы просто переводим его в двоичную систему и добавляем незначущие нули: {secondBin}\n");
            }
            (string resultBin,bool isnegative)= BinaryOperation.Result(firstBin, secondBin, additional);
            Console.WriteLine($"Результат побитового сложения будет равен {firstBin} + {secondBin} = {resultBin}\n");
            int resultDec = isnegative
                ? -TranslationIntoSystems.ToDec(resultBin)
                : TranslationIntoSystems.ToDec(resultBin);
            Console.WriteLine($"Далее полученный результат мы просто переводим в двоичную систему счисления: {resultDec}\n");
            if(Console.ReadLine() == string.Empty) return;
        }
    }
}
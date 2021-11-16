using System;
using System.Threading.Channels;

namespace binary_calculator
{
    public class AdditionalCode
    {
        public static void AdditionalBinCode()
        {
            Console.Clear();
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            string numberBin = TranslationIntoSystems.ToBin(number);
            bool NaN;
            try
            {
                if (number >= 0)
                    throw new Exception("Число не отрицательное");
                Console.WriteLine($"Так как число отрицательное, мы сначала переводим его в двоичную систему по модулю: {TranslationIntoSystems.ToBin(number)}");
                (numberBin,NaN)= NegativeValue.AdditionalCode(number, numberBin.Length);
                Console.WriteLine($"Затем в полученной записи, мы инверсируем все биты и добавляем незначущую \"1\": {BinaryOperation.Minus(numberBin,"1")}");
                Console.WriteLine("Далее к полученной записи мы прибавляем \"1\"");
                Console.WriteLine($"Полученный результат: {numberBin}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                numberBin = TranslationIntoSystems.ToBin(number);
                Console.WriteLine($"Так как введенное число не отрицательное, мы просто переводим его в двоичную систему: {numberBin}");
            }
            if(Console.ReadLine() == string.Empty) return;
        }
    }
}
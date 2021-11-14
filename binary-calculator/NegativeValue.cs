namespace binary_calculator
{
    public class NegativeValue
    {
        public static (string,bool) AdditionalCode(int number)
        {
            string firstBin = TranslationIntoSystems.ToBin(number);
            firstBin = BinaryOperation.Inverse(firstBin);
            firstBin = BinaryOperation.AddNonSignPoint(firstBin,firstBin.Length);
            firstBin = BinaryOperation.Plus(firstBin, "1");
            return (firstBin,true);
        }
    }
}
namespace binary_calculator
{
    public class NegativeValue
    {
        public static (string,bool) Negative(int number)
        {
            string firstBin = Program.ToBin(number);
            firstBin = BinaryOperation.Inverse(firstBin);
            firstBin = BinaryOperation.AddNonSignPoint(firstBin,firstBin.Length);
            firstBin = BinaryOperation.Plus(firstBin, "1");
            return (firstBin,true);
        }
    }
}
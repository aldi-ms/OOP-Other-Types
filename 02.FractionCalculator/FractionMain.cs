using System;

namespace _02.FractionCalculator
{
    public class FractionMain
    {
        public static void Main()
        {
            Fraction frac1 = new Fraction(22, 7);
            Fraction frac2 = new Fraction(40, 4);

            Console.WriteLine("{0} + {1} = {2}", frac1, frac2, frac1 + frac2);
            Console.WriteLine("{0} - {1} = {2}", frac1, frac2, frac1 - frac2);

            Console.ReadKey();
        }
    }
}

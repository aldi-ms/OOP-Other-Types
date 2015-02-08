using System;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long
            numerator,
            denominator;

        public Fraction(long numerator, long denominator)
        {
            this.numerator = numerator;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be 0!");
            }

            this.denominator = denominator;
        }

        #region Properties
        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }

            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be 0!");
                }
                this.denominator = value;
            }
        }
        #endregion

        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.Denominator != b.Denominator)
            {
                try
                {
                    checked
                    {
                        long numerator = a.Numerator * b.Denominator;
                        long denominator = a.Denominator * b.Denominator;
                        b.Numerator *= a.Denominator;
                        b.Denominator *= a.Denominator;
                        a.Numerator = numerator;
                        a.Denominator = denominator;
                    }
                }
                catch(OverflowException e) 
                {
                    throw new OverflowException("Long type overflow!", e);
                }
            }

            return new Fraction(a.Numerator + b.Numerator, a.denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            if (a.Denominator != b.Denominator)
            {
                try
                {
                    checked
                    {
                        long numerator = a.Numerator * b.Denominator;
                        long denominator = a.Denominator * b.Denominator;
                        b.Numerator *= a.Denominator;
                        b.Denominator *= a.Denominator;
                        a.Numerator = numerator;
                        a.Denominator = denominator;
                    }
                }
                catch (OverflowException e)
                {
                    throw new OverflowException("Long type overflow!", e);
                }
            }

            return new Fraction(a.Numerator - b.Numerator, a.denominator);
        }

        public override string ToString()
        {
            return ((double)this.Numerator / this.Denominator).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public static Rational NaN = new Rational(1, 0);

        public Rational()
        {
            throw new ArgumentException();
        }

        public bool IsNan
        {
            get
            {
                return 0 == Denominator;
            }
        }

        public void ToShort()
        {
            if (denominator == 0)
            {
                numerator = 1;
            }
            else
            {
                if (numerator == 0)
                {
                    denominator = 1;
                }
            }
            if (!IsNan)
            {
                if (
                    (denominator != 1)
                    &&
                    (denominator != -1)
                )
                {
                    if (numerator % denominator == 0)
                    {
                        numerator /= denominator;
                        denominator = 1;
                    }
                }

                if (
                    (numerator != 0)
                    &&
                    ((numerator != 1))
                    &&
                    ((numerator != -1))
                )
                {
                    if (denominator % numerator == 0)
                    {
                        denominator /= numerator;
                        numerator = 1;
                    }
                }

                if (denominator < 0)
                {
                    numerator *= -1;
                    denominator *= -1;
                }
            }
        }

        public int numerator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
                if (0 == value)
                {
                    denominator = 1;
                }
            }
        }

        private int denominator;
        public int Denominator
        {
            get {
                return denominator;
            }
            set
            {
                denominator = value;
            }
        }

        public Rational(int n, int d = 1)
        {
            this.Numerator = n;
            this.Denominator = d;
            ToShort();
        }

        public static Rational operator +(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
            {
                return NaN;
            }
            return new Rational(
                a.Numerator * b.Denominator + a.Denominator * b.Numerator,
                a.Denominator * b.Denominator
            );
        }

        public static Rational operator -(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
            {
                return NaN;
            }
            return new Rational(
                a.Numerator * b.Denominator - a.Denominator * b.Numerator, 
                a.Denominator * b.Denominator
            );
        }

        public static Rational operator *(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
            {
                return NaN;
            }
            return new Rational(
                a.Numerator * b.Numerator,
                a.Denominator * b.Denominator
            );
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
            {
                return NaN;
            }
            return new Rational(
                a.Numerator * b.Denominator,
                a.Denominator * b.Numerator
            );
        }

        public static explicit operator int (Rational a)
        {
            if (a.Denominator != 1)
            {
                throw new ArgumentException();
            }
            return (a.Numerator);
        }

        public static implicit operator double(Rational a)
        {
            if (a.IsNan)
            {
                return double.NaN;
            }
            return (double)a.Numerator / a.Denominator;
        }

        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }
    }
}
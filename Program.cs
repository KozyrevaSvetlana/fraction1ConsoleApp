using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractions
{
    public class Fraction
    {
        /// <summary>
        /// Числитель
        /// </summary>
        public int Numerator;
        /// <summary>
        /// Знаменатель
        /// </summary>
        public int Denomenator;
        /// <summary>
        /// знак дроби
        /// </summary>
        public int sign;

        public Fraction(int numerator, int denomenator)
        {
            if (numerator >= 0 && denomenator >= 0)
            {
                sign = 1;
            }
            if (numerator < 0 || denomenator < 0)
            {
                sign = -1;
            }
            if (numerator <= 0 && denomenator <= 0)
            {
                sign = 1;
            }
            Numerator = Math.Abs(numerator);
            Denomenator = Math.Abs(denomenator);
        }
        public Fraction(int numerator) : this(numerator, 1)
        {

            sign = numerator >= 0 ? 1 : -1;
            Numerator = Math.Abs(numerator);
        }

        public void Print()
        {
            if (Numerator < Denomenator)//числитель меньше знаменателя
            {
                int result = GreatestCommonDivisor();
                if (result == 1)
                {
                    Console.WriteLine($"{Numerator}/{Denomenator}");
                }
                else
                {
                    Console.WriteLine($"{Numerator / result}/{Denomenator / result}");
                }
            }
            if (Numerator == Denomenator)
            {
                Numerator = 1;
                Denomenator = 1;
                Console.WriteLine("1");
            }
            if (Numerator > Denomenator)//числитель больше знаменателя
            {
                int result = GreatestCommonDivisor();
                if (result == 1)
                {
                    if (Denomenator == 1)
                    {
                        Console.WriteLine(Numerator);
                    }
                    else
                    {
                        int integer = Numerator / Denomenator;
                        Console.WriteLine($"{integer} {Numerator - integer * Denomenator}/{Denomenator}");
                    }
                }
                else
                {
                    if (Denomenator / result == 1)
                    {
                        Console.WriteLine($"{Numerator / result}");
                    }
                    else
                    {
                        if (Numerator > Denomenator)
                        {
                            int integer = Numerator / Denomenator;
                            Console.WriteLine($"{integer} {Numerator / result - Denomenator / result}/{Denomenator / result}");
                        }
                        else
                        {
                            Console.WriteLine($"{Numerator / result}/{Denomenator / result}");
                        }
                    }
                }
            }
        }

        public Fraction Sum(Fraction otherFraction)
        {
            int commonDenomenator = sign * Denomenator * otherFraction.Denomenator * otherFraction.sign;

            int resultNumerator = (sign * otherFraction.sign) * (Numerator * otherFraction.Denomenator + otherFraction.Numerator * Denomenator);

            Fraction result = new Fraction(resultNumerator, commonDenomenator);
            return result;
        }
        public Fraction Difference(Fraction otherFraction)
        {
            int commonDenomenator = Denomenator * otherFraction.Denomenator;

            int resultNumerator = (Numerator * otherFraction.Denomenator - otherFraction.Numerator * Denomenator);

            Fraction result = new Fraction(resultNumerator, commonDenomenator);
            return result;
        }
        public Fraction Multiply(Fraction otherFraction)
        {
            Fraction result = new Fraction(Numerator * otherFraction.Numerator, Denomenator * otherFraction.Denomenator);
            return result;
        }
        public Fraction Divide(Fraction otherFraction)
        {
            Fraction result = new Fraction(Numerator * otherFraction.Denomenator, Denomenator * otherFraction.Numerator);
            return result;
        }
        public Fraction Sum(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Sum(otherFraction);
            return result;
        }
        public Fraction Difference(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Difference(otherFraction);
            return result;
        }
        public Fraction Multiply(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Multiply(otherFraction);
            return result;
        }
        public Fraction Divide(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Divide(otherFraction);
            return result;
        }

        /// <summary>
        /// Наибольший общий делитель (НОД)
        /// </summary>
        /// <returns></returns>
        public int GreatestCommonDivisor()
        {
            int a = Numerator;
            int b = Denomenator;
            while ((a != 0) && (b != 0))
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return a + b;
        }

        public void fractionСonversion(int Numerator, int Denomenator, int)
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(-19, 17);
            fraction1.Print();

            // проверить отрицательные значения
        }
    }
}


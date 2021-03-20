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
            if (Numerator == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (Numerator == Denomenator)
                {
                    Console.WriteLine("1");
                }
                else
                {
                    Console.WriteLine(sign == 1 ? $"{Numerator}/{Denomenator}" : $"-{Numerator}/{Denomenator}");
                }
            }

        }

        public Fraction Sum(Fraction otherFraction)
        {
            Fraction result = new Fraction(0, 0);
            if (sign == 1 && otherFraction.sign == 1)
            {
                result.Denomenator = Denomenator * otherFraction.Denomenator;
                result.Numerator = Numerator * otherFraction.Denomenator + otherFraction.Numerator * Denomenator;
            }
            if (sign == 1 && otherFraction.sign == -1)
            {
                result=Difference(otherFraction);
            }
            if (sign == -1 && otherFraction.sign == 1)
            {
                Fraction sumFraction = new Fraction(sign* Numerator,Denomenator);
                result=otherFraction.Difference(sumFraction);
            }
            if (sign == -1 && otherFraction.sign == -1)
            {
                result.Denomenator = Denomenator * otherFraction.Denomenator;
                result.Numerator = Math.Abs(sign *Numerator * otherFraction.Denomenator + otherFraction.sign*otherFraction.Numerator * Denomenator);
                result.sign = -1;
            }
            result = GreatestCommonDivisor(result.Numerator,result.Denomenator,result.sign);
            return result;
        }
        public Fraction Difference(Fraction otherFraction)
        {
            if (sign==-1&& otherFraction.sign==-1)
            {
                Fraction sumFraction = new Fraction(otherFraction.Numerator, otherFraction.Denomenator);
                Sum(sumFraction);
            }
            else
            {
                int commonDenomenator = Denomenator * otherFraction.Denomenator;
                int resultNumerator = Numerator * otherFraction.Denomenator - otherFraction.Numerator * Denomenator;
                Fraction result = new Fraction(resultNumerator, commonDenomenator);
                return GreatestCommonDivisor(result.Numerator, result.Denomenator, result.sign);
            }
            return null;
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
        public Fraction GreatestCommonDivisor(int Numerator, int Denomenator, int sign)
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
            int commonDivisor = a + b;
            Fraction result = new Fraction((sign * Numerator / commonDivisor), (Denomenator / commonDivisor));
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(-3, 7);
            fraction1.Print();
            Fraction fraction2 = new Fraction(-2, 7);
            fraction2.Print();
            Fraction fraction3 = fraction1.Sum(fraction2);
            fraction3.Print();// 

            // проверить отрицательные значения первая и вторая дробь отрицательные
        }
    }
}


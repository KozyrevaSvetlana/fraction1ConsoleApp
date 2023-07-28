using System;

namespace fractions
{
    /// <summary>
    /// что-то
    /// </summary>
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
                if (Denomenator==1)
                {
                    Console.WriteLine(sign*Numerator);
                }
                else
                {
                    if (Numerator == Denomenator)
                    {
                        Console.WriteLine("1");
                    }
                    else
                    {
                        if (Numerator > Denomenator)
                        {
                            int integer = Numerator / Denomenator;
                            string result = $"{integer} {Numerator - Denomenator * integer}/{Denomenator}";
                            Console.WriteLine(sign == 1 ? result : $"-{result}");
                        }
                        else
                        {
                            Console.WriteLine(sign == 1 ? $"{Numerator}/{Denomenator}" : $"-{Numerator}/{Denomenator}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// сложение дробей
        /// </summary>
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
                result = Difference(otherFraction);
            }
            if (sign == -1 && otherFraction.sign == 1)
            {
                Fraction sumFraction = new Fraction(sign * Numerator, Denomenator);
                result = otherFraction.Difference(sumFraction);
            }
            if (sign == -1 && otherFraction.sign == -1)
            {
                result.Denomenator = Denomenator * otherFraction.Denomenator;
                result.Numerator = Math.Abs(sign * Numerator * otherFraction.Denomenator + otherFraction.sign * otherFraction.Numerator * Denomenator);
                result.sign = -1;
            }
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }
        /// <summary>
        /// вычитание дробей
        /// </summary>
        public Fraction Difference(Fraction otherFraction)
        {
            if (sign == -1 && otherFraction.sign == -1)
            {
                Fraction sumFraction = new Fraction(otherFraction.Numerator, otherFraction.Denomenator);
                Sum(sumFraction);
            }
            else
            {
                int commonDenomenator = Denomenator * otherFraction.Denomenator;
                int resultNumerator = Numerator * otherFraction.Denomenator - otherFraction.Numerator * Denomenator;
                Fraction result = new Fraction(resultNumerator, commonDenomenator);
                return Reduction(result.Numerator, result.Denomenator, result.sign);
            }
            return null;
        }
        /// <summary>
        /// умножение дробей
        /// </summary>
        public Fraction Multiply(Fraction otherFraction)
        {
            Fraction result = new Fraction(otherFraction.sign*sign * Numerator * otherFraction.Numerator, Denomenator * otherFraction.Denomenator);
            result=Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }
        /// <summary>
        /// деление дробей
        /// </summary>
        public Fraction Divide(Fraction otherFraction)
        {
            Fraction result = new Fraction((sign* otherFraction.sign*Numerator * otherFraction.Denomenator), Denomenator * otherFraction.Numerator);
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }
        /// <summary>
        /// сложение дроби и целого числа
        /// </summary>
        public Fraction Sum(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Sum(otherFraction);
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }

        /// <summary>
        /// Вычитание дроби и целого числа
        /// </summary>
        /// <returns></returns>
        public Fraction Difference(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Difference(otherFraction);
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }
        /// <summary>
        /// Умножение дроби и целого числа
        /// </summary>
        /// <returns></returns>
        public Fraction Multiply(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Multiply(otherFraction);
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }
        /// <summary>
        /// Деление дроби и целого числа
        /// </summary>
        /// <returns></returns>
        public Fraction Divide(int number)
        {
            Fraction otherFraction = new Fraction(number, 1);

            Fraction result = Divide(otherFraction);
            result = Reduction(result.Numerator, result.Denomenator, result.sign);
            return result;
        }

        /// <summary>
        /// Сокращение через Наибольший общий делитель (НОД)
        /// </summary>
        /// <returns>несокращаемая дробь</returns>
        public Fraction Reduction(int Numerator, int Denomenator, int sign)
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
}


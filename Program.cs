using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1, fraction2;
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("");
            СreateАraction(out fraction1, out fraction2);
            Arithmetic(fraction1, fraction2);

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - начать сначала");
                Console.WriteLine("2 - завершить работу");
                string answer = Console.ReadLine();
                int userAnswer = 0;
                Int32.TryParse(answer, out userAnswer);
                while (userAnswer <= 0 || userAnswer > 2)
                {
                    Console.WriteLine("1 - начать сначала");
                    Console.WriteLine("2 - завершить работу");
                    userAnswer = Convert.ToInt32(Console.ReadLine());
                    Int32.TryParse(answer, out userAnswer);
                }
                switch (userAnswer)
                {
                    case 1:
                        СreateАraction(out fraction1, out fraction2);
                        Arithmetic(fraction1, fraction2);
                        break;
                    case 2:
                        Console.WriteLine("Вы уверены, что хотите выйти?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "да")
                        {
                            System.Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        private static void Arithmetic(Fraction fraction1, Fraction fraction2)
        {
            Fraction resultFraction = new Fraction(0, 0);
            Console.WriteLine("Введите число");
            Console.WriteLine("1 - Сложение");
            Console.WriteLine("2 - Вычитание");
            Console.WriteLine("3 - Умножение");
            Console.WriteLine("4 - Деление");
            string answer = Console.ReadLine();
            int userAnswer = 0;
            Int32.TryParse(answer, out userAnswer);
            while (userAnswer <= 0 || userAnswer > 4)
            {
                Console.WriteLine("Введите верное число");
                Console.WriteLine("1 - Сложение");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                userAnswer = Convert.ToInt32(Console.ReadLine());
            }
            switch (userAnswer)
            {
                case 1:
                    Console.WriteLine("Результат сложения:");
                    resultFraction = fraction1.Sum(fraction2);//сложение
                    resultFraction.Print();
                    break;
                case 2:
                    Console.WriteLine("Результат вычитания");
                    resultFraction = fraction1.Difference(fraction2);//вычитание
                    resultFraction.Print();
                    break;
                case 3:
                    Console.WriteLine("Результат умножения");
                    resultFraction = fraction1.Multiply(fraction2);//умножение
                    resultFraction.Print();
                    break;
                case 4:
                    Console.WriteLine("Результат деления");
                    resultFraction = fraction1.Divide(fraction2);//деление
                    resultFraction.Print();
                    break;
            }
        }

        private static void СreateАraction(out Fraction fraction1, out Fraction fraction2)
        {
            fraction1 = new Fraction(0, 0);
            fraction2 = new Fraction(0, 0);
            Console.WriteLine("Ввод первой дроби");
            Console.WriteLine("Введите числитель");
            fraction1.Numerator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите знаменатель. Если хотите ввести целое число, то напишите 1");
            fraction1.Denomenator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Успешно создана дробь: ");
            fraction1.Print();
            Console.WriteLine("");

            Console.WriteLine("Ввод второй дроби");
            Console.WriteLine("Введите числитель");
            fraction2.Numerator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите знаменатель. Если хотите ввести целое число, то напишите 1");
            fraction2.Denomenator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Успешно создана дробь: ");
            fraction2.Print();
        }
    }
}


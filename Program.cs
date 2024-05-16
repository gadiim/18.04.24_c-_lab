using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Тема: Структури, перелік
//Модуль 8


namespace _18._04._24_c__lab
{

    //Task_1

    struct Fraction
    {
        public int Numerator;
        public int Denominator;

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Add(Fraction other)
        {
            int newNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
            int newDenominator = Denominator * other.Denominator;
            return Simplify(new Fraction(newNumerator, newDenominator));
        }

        public Fraction Subtract(Fraction other)
        {
            int newNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
            int newDenominator = Denominator * other.Denominator;
            return Simplify(new Fraction(newNumerator, newDenominator));
        }

        public Fraction Multiply(Fraction other)
        {
            int newNumerator = Numerator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return Simplify(new Fraction(newNumerator, newDenominator));
        }

        public Fraction Divide(Fraction other)
        {
            int newNumerator = Numerator * other.Denominator;
            int newDenominator = Denominator * other.Numerator;
            return Simplify(new Fraction(newNumerator, newDenominator));
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private Fraction Simplify(Fraction fraction)
        {
            int gcd = GreatestCommonDivisor(fraction.Numerator, fraction.Denominator);
            fraction.Numerator /= gcd;
            fraction.Denominator /= gcd;
            return fraction;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    // Task_2

    struct ComplexNumber
    {
        public double RealPart;
        public double ImaginaryPart;

        public ComplexNumber(double real, double imaginary)
        {
            RealPart = real;
            ImaginaryPart = imaginary;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            double realResult = RealPart + other.RealPart;
            double imaginaryResult = ImaginaryPart + other.ImaginaryPart;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            double realResult = RealPart - other.RealPart;
            double imaginaryResult = ImaginaryPart - other.ImaginaryPart;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Multiply(ComplexNumber other)
        {
            double realResult = RealPart * other.RealPart - ImaginaryPart * other.ImaginaryPart;
            double imaginaryResult = RealPart * other.ImaginaryPart + ImaginaryPart * other.RealPart;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public ComplexNumber Divide(ComplexNumber other)
        {
            double denominator = other.RealPart * other.RealPart + other.ImaginaryPart * other.ImaginaryPart;
            double realResult = (RealPart * other.RealPart + ImaginaryPart * other.ImaginaryPart) / denominator;
            double imaginaryResult = (ImaginaryPart * other.RealPart - RealPart * other.ImaginaryPart) / denominator;
            return new ComplexNumber(realResult, imaginaryResult);
        }

        public override string ToString()
        {
            if (ImaginaryPart >= 0)
                return $"{RealPart} + {ImaginaryPart}i";
            else
                return $"{RealPart} - {-ImaginaryPart}i";
        }
    }

    //Task_3

    struct Birthday
    {
        private DateTime Date;
        public Birthday()
        {
            Date = new DateTime(1999, 4, 18);
        }
        public DayOfWeek GetBirthDay()
        {
            return Date.DayOfWeek;
        }
        public DayOfWeek GetFutureBirthDay(int year)
        {
            DateTime birthday = new DateTime(year, Date.Month, Date.Day);
            return birthday.DayOfWeek;
        }
        public int GetLeftDays()
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, Date.Month, Date.Day);

            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            int daysUntilBirthday = 0;

            while (today < nextBirthday)
            {
                today = today.AddDays(1);
                daysUntilBirthday++;
            }
            return daysUntilBirthday;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            //Завдання 1
            //Створіть структуру «Дріб». Вона повинна мати поля
            //для зберігання чисельника і знаменника.Реалізуйте наступну функціональність:
            //■ Додавання дробів;
            //■ Віднімання дробів;
            //■ Множення дробів;
            //■ Ділення дробів.

            Console.WriteLine($"Task 1\n");

            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(3, 4);

            Console.WriteLine("Fraction 1: " + fraction1);
            Console.WriteLine("Fraction 2: " + fraction2);

            // Додавання
            Fraction sum = fraction1.Add(fraction2);
            Console.WriteLine("Sum: " + sum);

            // Віднімання
            Fraction difference = fraction1.Subtract(fraction2);
            Console.WriteLine("Difference: " + difference);

            // Множення
            Fraction product = fraction1.Multiply(fraction2);
            Console.WriteLine("Product: " + product);

            // Ділення
            Fraction quotient = fraction1.Divide(fraction2);
            Console.WriteLine("Quotient: " + quotient);

            Console.WriteLine("\npress any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 2
            //Створіть структуру «Комплексне число». Визначте в
            //ній необхідні поля та методи.Реалізуйте наступну функціональність:
            //■ Додавання комплексних чисел;
            //■ Віднімання комплексних чисел;
            //■ Множення комплексних чисел;
            //■ Ділення комплексних чисел.
            //Докладніше про комплексні числа та операції над
            //ними можна прочитати тут: https://en.wikipedia.org/wiki/
            //            Комплексне_число.


            Console.WriteLine($"Task 2\n");

            ComplexNumber num1 = new ComplexNumber(3, 2);
            ComplexNumber num2 = new ComplexNumber(1, -4);

            Console.WriteLine("Complex Number 1: " + num1);
            Console.WriteLine("Complex Number 2: " + num2);

            // Додавання
            ComplexNumber additionResult = num1.Add(num2); // Змінено назву змінної на additionResult
            Console.WriteLine("Sum: " + additionResult); // Використано нову назву змінної

            // Віднімання
            ComplexNumber subtractResult = num1.Subtract(num2); // Змінено назву змінної на subtractResult
            Console.WriteLine("Difference: " + subtractResult); // Використано нову назву змінної

            // Множення
            ComplexNumber productResult = num1.Multiply(num2);
            Console.WriteLine("Product: " + productResult);

            // Ділення
            ComplexNumber divisionResult = num1.Divide(num2);
            Console.WriteLine("Quotient: " + divisionResult);

            Console.WriteLine("\npress any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 3
            //Створіть структуру «День народження». Визначте в
            //ній необхідні поля і методи.Реалізуйте наступну функціональність:
            //■ Встановлення дати дня народження;
            //■ Визначення дня тижня, коли народився іменинника;
            //■ Визначення дня тижня у зазначеному році, коли буде
            //день народження.Наприклад, день народження припадає на 1 квітня
            //і нам потрібно дізнатися, який це буде день тижня у 2025 році.
            //Правильна відповідь — вівторок;
            //■ Визначення кількості днів до дня народження.


            Console.WriteLine($"Task 3\n");

            Birthday birthday = new Birthday();

            Console.WriteLine($"birthday in 1999:\t{birthday.GetBirthDay()}");
            Console.WriteLine($"birthday in 2024:\t{birthday.GetFutureBirthDay(2024)}");
            Console.WriteLine($"left {birthday.GetLeftDays()} days until birthday");
            Console.WriteLine();

        }
    }
}

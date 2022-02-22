using System;
using Ilesson;

namespace LessonsLib
{
    public class Lesson1_1:ILesson
    {
        public string LessonID { get => "1"; }

        public string Description { get => "Алгоритм проверки простого числа"; }

        /// <summary>
        /// Определение число простое или нет
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Истина - простое, Ложь - нет</returns>
        /// <exception cref="ArgumentException"></exception>
        private bool CheckPrimeNumber(long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive");

            }
            if (number == 0 || number == 1)
            {
                return false;

            }
            long d = 0;
            long i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Тестирование метода CheckPrimeNumber
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <param name="expected">Ожидаемый результат (истина - простое, ложь - нет)</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        private void TestPrimeNumber(long number, bool expected = false, string expectedException = null)
        {
            try
            {
                bool actual = CheckPrimeNumber(number);
                if (actual == expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == expectedException)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("Алгоритм проверки простого числа");
            Console.WriteLine();
            Console.Write($"Тест№1. Число {-150,-7}- ");
            TestPrimeNumber(-150, expectedException: "Number must be positive");
            Console.Write($"Тест№2. Число {1,-7}- ");
            TestPrimeNumber(1, false);
            Console.Write($"Тест№3. Число {16,-7}- ");
            TestPrimeNumber(16, false);
            Console.Write($"Тест№4. Число {2,-7}- ");
            TestPrimeNumber(2, true);
            Console.Write($"Тест№5. Число {47,-7}- ");
            TestPrimeNumber(47, true);
            Console.Write($"Тест№6. Число {199,-7}- ");
            TestPrimeNumber(199, true);
            Console.WriteLine("");
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }

    }
}

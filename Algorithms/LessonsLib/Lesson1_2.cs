using System;
using Ilesson;

namespace LessonsLib
{
    public class Lesson1_2: ILesson
    {
        public string LessonID { get => "2"; }

        public string Description { get => "Расчет числа Фибоначчи"; }

        /// <summary>
        /// Вычисления числа Фибоначчи
        /// </summary>
        /// <param name="number">Позиция числа</param>
        /// <returns>Число</returns>
        private long CalcFibonacci(long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive");

            }
            if (number == 0 || number == 1)
            {
                return number;
            }
            else
            {
                return CalcFibonacci(number - 1) + CalcFibonacci(number - 2);
            }
        }

        /// <summary>
        /// Тестирование метода CalcFibonacci
        /// </summary>
        /// <param name="number">Проверяемая позиция числа</param>
        /// <param name="expected">Ожидаемый результат</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        private void TestFibonacci(long number, long expected = 0, string expectedException = null)
        {

            try
            {
                long actual = CalcFibonacci(number);
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
            Console.WriteLine("Расчет числа Фибоначчи");
            Console.WriteLine();
            Console.Write($"Тест№1. Кол-во элементов {-7,-7}. ");
            TestFibonacci(-7, expectedException: "Number must be positive");
            Console.Write($"Тест№2. Кол-во элементов {0,-7}. ");
            TestFibonacci(0, 0);
            Console.Write($"Тест№3. Кол-во элементов {6,-7}- ");
            TestFibonacci(6, 8);
            Console.Write($"Тест№4. Кол-во элементов {27,-7}- ");
            TestFibonacci(27, 196418);
            Console.Write($"Тест№5. Кол-во элементов {2,-7}- ");
            TestFibonacci(1, 1);
            Console.WriteLine("");
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }

    }
}

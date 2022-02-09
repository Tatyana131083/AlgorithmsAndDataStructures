using System;

namespace Algorithms
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Алгоритм проверки простого числа");
                Console.WriteLine("2. Расчет числа Фибоначчи");
                Console.WriteLine("3. Двусвязанный список");
                Console.WriteLine("Для выхода нажмите ESC");
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            PrintPrimeNumberTest();
                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            PrintFibonacciTest();
                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            Lesson2.TestTwoLinkedList();
                            break;
                        }
                    default: 
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Введен неверный пункт меню.");
                            Console.Write("Нажмите любую кнопку для продолжения...");
                            Console.ReadKey();
                            break; 
                        }

                }
            }
            
        }


        static bool CheckPrimeNumber(long number)
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
                if(number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if(d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        static void TestPrimeNumber(long number, bool expected = false, string expectedException = null)
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

        static void PrintPrimeNumberTest()
        {
            Console.Clear();
            Console.WriteLine("Алгоритм проверки простого числа");
            Console.WriteLine();
            Console.Write($"Тест№1. Число {-150,-7}- ");
            TestPrimeNumber(-150, expectedException : "Number must be positive");
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


        static long CalcFibonacci(long number)
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

        static void TestFibonacci(long number, long expected = 0, string expectedException = null)
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

        static void PrintFibonacciTest()
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
            Console.Write($"Тест№4. Кол-во элементов {27, -7}- ");
            TestFibonacci(27, 196418);
            Console.Write($"Тест№5. Кол-во элементов {2, -7}- ");
            TestFibonacci(1, 1);
            Console.WriteLine("");
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }

        


    }
}

using System;
using System.Collections.Generic;

namespace Algorithms
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<ILesson> lessons = new List<ILesson>();
            lessons.Add((ILesson)new Lesson1_1());
            lessons.Add((ILesson)new Lesson1_2());
            lessons.Add((ILesson)new Lesson2());
            lessons.Add((ILesson)new Lesson3());
            lessons.Add((ILesson)new Lesson4());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                foreach(ILesson lesson in lessons)
                {
                    Console.WriteLine($"{lesson.LessonID}. {lesson.Description}");
                }
                Console.WriteLine();
                Console.WriteLine("Для выхода нажмите ESC");
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            lessons[0].Print();
                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            lessons[1].Print();
                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            lessons[2].Print();
                            break;
                        }
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        {
                            lessons[3].Print();
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        {
                            lessons[4].Print();
                            Console.ReadKey();
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

    }
}

using Ilesson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Algorithms
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var libraryPath = @"C:\Users\yalli\source\repos\AlgorithmsAndDataStructures\Algorithms\LessonsLib\bin\Debug\net5.0\LessonsLib.dll";
            Assembly assembly = Assembly.LoadFrom(libraryPath);
            var classesLib = assembly.GetTypes();
            List<ILesson> lessons = new List<ILesson>();
            foreach (Type type in classesLib)
            {
                lessons.Add((ILesson)Activator.CreateInstance(type));
            }
            string userChoice = string.Empty;
            while (userChoice != "exit")
            {
                bool isRightLesson = false;
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                foreach(ILesson lesson in lessons)
                {
                    Console.WriteLine($"{lesson.LessonID}. {lesson.Description}");
                }
                Console.WriteLine();
                Console.WriteLine("Для выхода напечатайте exit");
                userChoice = Console.ReadLine();
                foreach (ILesson lesson in lessons)
                {
                    if (userChoice == lesson.LessonID)
                    {
                        isRightLesson = true;
                        lesson.Print();
                    }
                }
                if (!isRightLesson && userChoice != "exit")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Введен неверный пункт меню.");
                    Console.Write("Нажмите любую кнопку для продолжения...");
                    Console.ReadKey();
                }
               
            }

        }

    }
}

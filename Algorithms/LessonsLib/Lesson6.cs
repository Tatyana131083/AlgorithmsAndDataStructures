using System;
using Ilesson;
using System.Numerics;

namespace LessonsLib
{
    internal class Lesson6 : ILesson
    {
        public string LessonID { get => "7"; }

        public string Description { get => "Задача на количество вариантов пути в последовательности от 1 до 100"; }


        /// <summary>
        /// Расчет количества вариантов пути в массиве
        /// </summary>
        private void СalculationNumberOfVariant(BigInteger[,] numberOfVariant)
        {
            //первая горизонталь и первая вертикаль - 1
            for (int i = 0; i < numberOfVariant.GetLength(0); i++)
            {
                numberOfVariant[0, i] = 1;
            }
            for (int i = 0; i < numberOfVariant.GetLength(1); i++)
            {
                numberOfVariant[i, 0] = 1;
            }

            for (int i = 1; i < numberOfVariant.GetLength(0); i++)
                for (int j = 1; j < numberOfVariant.GetLength(1); j++)
                {
                    numberOfVariant[i, j] = numberOfVariant[i - 1, j] + numberOfVariant[i, j - 1];
                }
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("Количество вариантов пути в последовательности от 1 до 100");
            int n = GetDimensions("N");
            int m = GetDimensions("M");
            BigInteger[,] numberOfVariant = new BigInteger[n, m];
            СalculationNumberOfVariant(numberOfVariant);
            /*for (int i = 0; i < numberOfVariant.GetLength(0); i++)
            {
                for (int j = 0; j < numberOfVariant.GetLength(1); j++)
                {
                    Console.Write($"{numberOfVariant[i, j],-10}  ");
                }
                Console.WriteLine();
            }*/
            Console.WriteLine($"Количество вариантов пути: {numberOfVariant[n - 1, m - 1]}  ");
            Console.WriteLine();
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();

        }

        /// <summary>
        /// Получение размерности от пользователя через консоль
        /// </summary>
        /// <param name="dimension">Название размерности (n, m)</param>
        /// <returns>Размерность</returns>
        private int GetDimensions(string dimension)
        {
            bool isCorrect = false;
            int numberInt = 0;
            while (!isCorrect)
            {
                Console.WriteLine($"Введите размерность {dimension} от 1 до 100");
                string n = Console.ReadLine();
                numberInt = 0;
                if (int.TryParse(n, out numberInt) & numberInt >= 1 & numberInt <= 100)
                {
                    isCorrect = true;
                    
                }
                else
                {
                    isCorrect = false;
                    Console.WriteLine("Ошибка ввода. Введите число от 1 до 100.");
                    Console.ReadKey();
                }
            }
            return numberInt;

        }
    }
}
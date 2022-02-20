using System;
using System.Diagnostics;
using Ilesson;
using AlgorithmsLib;



namespace LessonsLib
{
     internal class Lesson3 : ILesson
    {
        public string LessonID { get => "4"; }
        
        public string Description { get => "Замеры длительности выполнения методов расчета расстояние между парой точек."; }

        public void Print()
        {
            Console.Clear();
            PointClass[,] arrayPointV1 = CreateArrayPointClass(100000);
            double timeForPointV1 = PointDistanceForArray(arrayPointV1);
            PointClass[,] arrayPointV2 = CreateArrayPointClass(200000);
            double timeForPointV2 = PointDistanceForArray(arrayPointV2);
            PointStruct[,] arrayStructV1 = CreateArrayPointStruct(100000);
            double timeForStructV1 = PointDistanceForArray(arrayStructV1);
            PointStruct[,] arrayStructV2 = CreateArrayPointStruct(200000);
            double timeForStructV2 = PointDistanceForArray(arrayStructV2);

            Console.WriteLine($"{"Количество точек", -20} {"PointStructDouble", -30} {"PointClassDouble", -30} {"Ratio", -30}");
            Console.WriteLine($"{"100000",-20} {timeForStructV1,-30} {timeForPointV1,-30} {(timeForStructV1 / timeForPointV1)*100,-30}");
            Console.WriteLine($"{"200000",-20} {timeForStructV2,-30} {timeForPointV2,-30} {(timeForStructV2 / timeForPointV2)*100,-30}");
            Console.WriteLine();
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }
        /// <summary>
        /// Создание двухмерного массива точек, инициализированных случайным значение
        /// </summary>
        /// <param name="n">Кол-во элементов</param>
        /// <returns>Массив точек</returns>
        public PointClass[,] CreateArrayPointClass(int n)
        {
            PointClass [,] array = new PointClass[n, 2];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new PointClass();
                    array[i, j].X = GetRandomNumber(-500, 500);
                    array[i, j].Y = GetRandomNumber(-500, 500);
                }
            }
            return array;
        }

        /// <summary>
        /// Создание двухмерного массива точек, инициализированных случайным значение
        /// </summary>
        /// <param name="n">Кол-во элементов</param>
        /// <returns>Массив точек</returns>
        public PointStruct[,] CreateArrayPointStruct(int n)
        {
            PointStruct[,] array = new PointStruct[n, 2];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new PointStruct();
                    array[i, j].X = GetRandomNumber(-500, 500);
                    array[i, j].Y = GetRandomNumber(-500, 500);
                }
            }
            return array;
        }

        /// <summary>
        /// Получение случайного числа
        /// </summary>
        /// <param name="minimum">Нижняя граница</param>
        /// <param name="maximum">Верхняя граница</param>
        /// <returns>Случайное число</returns>
        private double GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next(minimum, maximum -1) + random.NextDouble();
        }

        /// <summary>
        /// Расчет расстояния между двумя точками
        /// </summary>
        /// <param name="pointOne">Точка 1</param>
        /// <param name="pointTwo">Точка 2</param>
        /// <returns>Расстояние</returns>
        public double PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Расчет расстояния между двумя точками
        /// </summary>
        /// <param name="pointOne">Точка 1</param>
        /// <param name="pointTwo">Точка 2</param>
        /// <returns>Расстояние</returns>
        public double PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Расчет расстояние между двумя точками в двумерном массиве
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Время выполнения</returns>
        public double PointDistanceForArray(PointClass[,] array)
        {
            Stopwatch sw = new Stopwatch();
            double time = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sw.Start();
                PointDistance(array[i, 0], array[i, 1]);
                sw.Stop();
                time += sw.Elapsed.TotalSeconds;
                sw.Reset();
            }
            return time;
        }

        /// <summary>
        /// Расчет расстояние между двумя точками в двумерном массиве
        /// </summary>
        /// <param name="array">Массив</param>
        /// /// <returns>Время выполнения</returns>
        public double PointDistanceForArray(PointStruct[,] array)
        {
            Stopwatch sw = new Stopwatch();
            double time = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sw.Start();
                PointDistance(array[i, 0], array[i, 1]);
                sw.Stop();
                time += sw.Elapsed.TotalSeconds;
                sw.Reset();
            }
            return time;
        }
    }
}

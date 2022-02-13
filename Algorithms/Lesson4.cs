using System;


namespace Algorithms
{
    internal class Lesson4 : ILesson
    {
        private const int COLUMN_WIDTH = 5;

        public string LessonID { get => "5"; }

        public string Description { get => "Двоичное дерево поиска"; }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("Двоичное дерево поиска");
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new TreeNode<int>() { Data = 50 };            
            tree.Add(25);
            tree.Add(75);
            tree.Add(1);
            tree.Add(200);
            tree.Add(45);
            tree.Add(51);
            VisualizeTree(tree);
            Console.WriteLine();
            Console.WriteLine("Двоичное дерево с удаленным узлом 75");
            tree.Remove(75);
            VisualizeTree(tree);
            Console.WriteLine("Поиск узла со значением 200");
            if (tree.Find(200) == null) {
                Console.WriteLine("Узел не найден");
            }
            else
            {
                Console.WriteLine("Узел найден");
            }
            Console.WriteLine("Поиск узла со значением 77");
            if (tree.Find(77) == null)
            {
                Console.WriteLine("Узел не найден");
            }
            else
            {
                Console.WriteLine("Узел найден");
            }
        }
        /// <summary>
        /// Вывод двоичного дерева поиска на консоль
        /// </summary>
        /// <param name="tree">Двоичное дерево поиска</param>
        private static void VisualizeTree(BinarySearchTree<int> tree)
        {
            char[][] console = InitializeArray(tree, out int width);
            VisualizeNode(tree.Root, 0, width / 2, console, width);
            foreach (char[] row in console)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Создание массива для хранения значений узлов дерева, в порядке, котором элементы расположены согласно их выводу в консоли
        /// </summary>
        /// <param name="tree">Корень дерева</param>
        /// <param name="width">Кол-во элементов нижнего уровня</param>
        /// <returns>Кол-во элементов нижнего уровня</returns>
        private static char[][] InitializeArray(BinarySearchTree<int> tree, out int width)
        {
            int height = tree.GetHeight();
            width = (int)Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < height * 2; i++)
            {
                console[i] = new char[COLUMN_WIDTH * width];
            }
            for(int i = 0; i < console.Length; i++)
            {
                for (int j = 0; j < console[i].Length; j++)
                {
                    console[i][j] = ' ';
                }                       
            }
            return console;
        }

        /// <summary>
        /// Заполнение массива информацией об узле 
        /// </summary>
        /// <param name="node">Узел</param>
        /// <param name="row">Строка в массиве, зависит от высоты узла</param>
        /// <param name="column">Порядковый номер по горизонтали узла</param>
        /// <param name="console">Массив для хранения значение узлов дерева, в котором элементы расположены согласно их выводу в консоли</param>
        /// <param name="width">Кол-во элементов нижнего уровня дерева</param>
        private static void VisualizeNode(TreeNode<int> node, int row, int column, char[][] console, int width)
        {
            if (node != null)
            {
                //приводим значение узла к массиву char
                char[] chars = node.Data.ToString().ToCharArray();
                //находим позицию элемента в посередине столбца
                int margin = (COLUMN_WIDTH - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++)
                {
                    //COLUMN_WIDTH * column + i + margin позиция char элемента по горизонтали
                    console[row][COLUMN_WIDTH * column + i + margin]
                        = chars[i];
                }

                int delta = (width + 1) /
                    (int)Math.Pow(2, node.GetHeight() + 1);
                VisualizeNode(node.Left, row + 2, column - delta,
                    console, width);
                VisualizeNode(node.Right, row + 2, column + delta,
                    console, width);
            }
        }

    }
}

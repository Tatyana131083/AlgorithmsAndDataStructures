using System;


namespace Algorithms
{
    internal class Lesson4 : ILesson
    {


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
            tree.VisualizeTree();
            Console.WriteLine();
            Console.WriteLine("Двоичное дерево с удаленным узлом 75");
            tree.Remove(75);
            tree.VisualizeTree();
            Console.WriteLine("Поиск узла со значением 200");
            if (tree.Find(200) == null)
            {
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

    }
}

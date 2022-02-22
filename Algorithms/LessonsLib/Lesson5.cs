using System;
using System.Collections.Generic;
using Ilesson;
using AlgorithmsLib;

namespace LessonsLib
{
    internal class Lesson5 : ILesson

    {

        public string LessonID { get => "6"; }

        public string Description { get => "DFS и BFS поиск"; }

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
            tree.Add(47);
            tree.VisualizeTree();
            Console.WriteLine();
            Console.WriteLine("DFS (поиск в глубину)");
            List<TreeNode<int>> pathDFS = new List<TreeNode<int>>();
            bool result = false;
            pathDFS = tree.DFS(200, out result);
            foreach (TreeNode<int> treeNode in pathDFS)
            {
                Console.Write($"{treeNode.Data} ");
            }
            Console.Write(result);
            Console.WriteLine();
            Console.WriteLine("BFS (поиск в ширину)");
            List<TreeNode<int>> pathBFS = new List<TreeNode<int>>();
            pathBFS = tree.BFS(200, out result);
            foreach (TreeNode<int> treeNode in pathBFS)
            {
                Console.Write($"{treeNode.Data} ");
            }
            Console.Write(result);
            Console.WriteLine();
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }


    }
}

using System;
using Ilesson;
using AlgorithmsLib;

namespace LessonsLib
{
    internal class Lesson2:ILesson
    {
        public string LessonID { get => "3"; }

        public string Description { get => "Двусвязанный список"; }

        public void Print()
        {
            Console.Clear();
            TwoLinkedList<int> twoLinkedList = new TwoLinkedList<int>();
            Console.WriteLine("Вставка в конец списка");
            twoLinkedList.AddNode(10);
            twoLinkedList.AddNode(15);
            twoLinkedList.AddNode(18);
            twoLinkedList.AddNode(19);
            twoLinkedList.PrintList();
            Console.WriteLine("Вставка после элемента 10");
            Node<int> node = twoLinkedList.FindNode(10);
            if (node != null)
            {
                twoLinkedList.AddNodeAfter(node, 44);
            }
            twoLinkedList.PrintList();
            Console.WriteLine("Вставка после элемента 19");
            Node<int> node2 = twoLinkedList.FindNode(19);
            if (node != null)
            {
                twoLinkedList.AddNodeAfter(node2, 77);
            }
            twoLinkedList.PrintList();
            Console.WriteLine("Удаление первого элемента по индексу");
            twoLinkedList.RemoveNode(0);
            twoLinkedList.PrintList();
            Console.WriteLine("Удаление элемента 18 по индексу");
            twoLinkedList.RemoveNode(2);
            twoLinkedList.PrintList();
            Console.WriteLine("Удаление элемента 19  по узлу");
            node = twoLinkedList.FindNode(19);
            twoLinkedList.RemoveNode(node);
            twoLinkedList.PrintList();
            Console.WriteLine("Удаление элемента 77  по узлу");
            node2 = twoLinkedList.FindNode(77);
            twoLinkedList.RemoveNode(node2);
            twoLinkedList.PrintList();
            Console.WriteLine();
            Console.Write("Для выхода в главное меню нажмите любую кнопку...");
            Console.ReadKey();
        }

    }
}

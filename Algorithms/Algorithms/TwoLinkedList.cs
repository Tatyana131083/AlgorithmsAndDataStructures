using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class TwoLinkedList<T> : ILinkedList<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        /// <summary>
        /// Добавляет новый элемент в конец списка
        /// </summary>
        /// <param name="value">Значение нового узла</param>
        public void AddNode(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {

                Tail.NextNode = newNode;
                newNode.PrevNode = Tail;
                Tail = newNode;
            }
            return;
        }

        /// <summary>
        /// Добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node">Узел, после которого идет добавление нового узла</param>
        /// <param name="value">Значение нового узла</param>
        public void AddNodeAfter(Node<T> node, T value)
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> currentNode = Head;
            if (node == Tail)
            {
                AddNode(value);
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode == node)
                    {
                        Node<T> nextNode = currentNode.NextNode;
                        currentNode.NextNode = newNode;
                        newNode.PrevNode = currentNode;
                        newNode.NextNode = nextNode;
                        nextNode.PrevNode = newNode;
                    }
                    currentNode = currentNode.NextNode;
                }
            }
        }

        /// <summary>
        /// Сравнение на равенство двух объектов
        /// </summary>
        /// <param name="x">1 значение</param>
        /// <param name="y">2 значение</param>
        /// <returns>Истина, если объекты равны</returns>
        private bool Compare(T x, T y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Поиск элемента по его значению
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        /// <returns>Узел, с найденным значением или null</returns>
        public Node<T> FindNode(T searchValue)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                if (Compare(currentNode.Value, searchValue))
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return null;
        }


        /// <summary>
        ///Удаляет элемент по порядковому номеру, начинается  с 0
        /// </summary>
        /// <param name="index">Порядковый номер</param>
        public void RemoveNode(int index)
        {
            if (index + 1 > GetCount())
            {
                throw new ArgumentOutOfRangeException();
            }
            Node<T> currentNode = Head;

            //удаляем голову
            if (index == 0)
            {
                //в списке один элемент
                if (GetCount() == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.NextNode;
                    Head.PrevNode = null;
                }
                return;
            }
            else if (index == GetCount() - 1) //удаляем хвост
            {
                Tail = Tail.PrevNode;
                Tail.NextNode = null;

            }
            else
            //удаляем из середины списка
            {
                int counter = 0;
                while (counter < index)
                {
                    currentNode = currentNode.NextNode;
                    counter++;
                }
                Node<T> prevNode = currentNode.PrevNode;
                prevNode.NextNode = currentNode.NextNode;
                Node<T> nextNode = currentNode.NextNode;
                nextNode.PrevNode = prevNode;
            }
        }

        /// <summary>
        ///Удаляет указанный узел
        /// </summary>
        /// <param name="node">Узел, который удаляется</param>
        public void RemoveNode(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            Node<T> currentNode = Head;
            bool isRemove = false;
            //удаляем голову
            if (node == Head)
            {
                //в списке один элемент
                if (GetCount() == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.NextNode;
                    Head.PrevNode = null;
                }
                isRemove = true;
            }
            else if (node == Tail) //удаляем хвост
            {
                Tail = Tail.PrevNode;
                Tail.NextNode = null;
                isRemove = true;

            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode == node)
                    {
                        Node<T> prevNode = currentNode.PrevNode;
                        prevNode.NextNode = currentNode.NextNode;
                        Node<T> nextNode = currentNode.NextNode;
                        nextNode.PrevNode = prevNode;

                        isRemove = true;
                    }
                    currentNode = currentNode.NextNode;
                }
            }

            if (!isRemove)
            {
                throw new MissingFieldException();
            }
        }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        /// <returns>Количество элементов</returns>
        public int GetCount()
        {
            int count = 0;
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            return count;
        }

        /// <summary>
        /// Выводит список на консоль
        /// </summary>
        public void PrintList()
        {
            Node<T> currentNode = Head;
            do
            {
                Console.Write($"{currentNode.Value}\t");
                currentNode = currentNode.NextNode;
            }
            while (currentNode != null);
            Console.WriteLine();
        }


    }

}


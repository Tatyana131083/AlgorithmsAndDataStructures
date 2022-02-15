using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public TreeNode<T> Root { get; set; }
        public int Count { get; set; }

        private const int COLUMN_WIDTH = 5;

        /// <summary>
        /// Поиск места в дереве для добавления нового элемента
        /// </summary>
        /// <param name="data">Значение нового элемента</param>
        /// <returns>Родитель для нового элемента</returns>
        /// <exception cref="ArgumentException"></exception>
        private TreeNode<T> GetParentForNewNode(T data)
        {
            TreeNode<T> current = Root;
            TreeNode<T> parent = null;
            while (current != null)
            {
                parent = current;
                int result = data.CompareTo(current.Data);
                if (result == 0)
                {
                    throw new ArgumentException(
                        $"Узел {data} уже существует.");
                }
                else if (result < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return parent;
        }

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="data">Значение нового элемента</param>
        public void Add(T data)
        {
            TreeNode<T> parent = GetParentForNewNode(data);
            TreeNode<T> node = new TreeNode<T>() { Data = data, Parent = parent };

            if (parent == null)
            {
                Root = node;
            }
            else if (data.CompareTo(parent.Data) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }

            Count++;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="data">Удаляемый элемент</param>
        public void Remove(T data)
        {
            Remove(Root, data);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="node">Корень дерева</param>
        /// <param name="data">Удаляемый элемент</param>
        /// <exception cref="ArgumentException"></exception>
        private void Remove(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                throw new ArgumentException(
                    $"Узла {data} не существует.");
            }
            //поиск меньшего элемента
            else if (data.CompareTo(node.Data) < 0)
            {
                Remove(node.Left, data);
            }
            //поиск большего элемента
            else if (data.CompareTo(node.Data) > 0)
            {
                Remove(node.Right, data);
            }
            //найден узел для удаления
            else
            {
                //потомков нет
                if (node.Left == null && node.Right == null)
                {
                    ReplaceInParent(node, null);
                    Count--;
                }
                //нет правого потомка
                else if (node.Right == null)
                {
                    //левый на место удаляемого
                    ReplaceInParent(node, node.Left);
                    Count--;
                }
                //нет левого потомка
                else if (node.Left == null)
                {
                    //правый на место удаляемого
                    ReplaceInParent(node, node.Right);
                    Count--;
                }
                //есть оба потомка
                else
                {
                    //находим минимальный элемент в правом поддереве
                    TreeNode<T> minNode = node.Left;
                    while (minNode.Left != null)
                    {
                        minNode = node.Left;
                    }
                    //меняем на текущего значение 
                    node.Data = minNode.Data;
                    //найденный удаляем
                    Remove(minNode, minNode.Data);
                }
            }
        }

        /// <summary>
        /// Изменение ссылки родительского узла на новый
        /// </summary>
        /// <param name="node">Узел</param>
        /// <param name="newNode">Новый узел</param>
        private void ReplaceInParent(TreeNode<T> node, TreeNode<T> newNode)
        {
            if (node.Parent != null)
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = newNode;
                }
                else
                {
                    node.Parent.Right = newNode;
                }
            }
            else
            {
                Root = newNode;
            }

            if (newNode != null)
            {
                newNode.Parent = node.Parent;
            }
        }

        /// <summary>
        /// Определение высоты дерева от корня
        /// </summary>
        /// <returns>Высоту дерева</returns>
        private int GetHeight(TreeNode<T> root)
        {
            int height = 0;
            if (root == null)
            {
                return height;
            }
            int leftHeight = GetHeight(root.Left);
            int RightHeight = GetHeight(root.Right);
            return Math.Max(leftHeight, RightHeight) + 1;
        }

        /// <summary>
        /// Определение высоты дерева от корня
        /// </summary>
        /// <returns>Высоту дерева</returns>
        public int GetHeight()
        {
            return GetHeight(Root);
        }

        /// <summary>
        /// Поиск узла по значению
        /// </summary>
        /// <param name="data">Значение</param>
        /// <returns>Узел</returns>
        public TreeNode<T> Find(T data)
        {
            TreeNode<T> node = Root;
            while (node != null)
            {
                int result = data.CompareTo(node.Data);
                if (result == 0)
                {
                    return node;
                }
                else if (result < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return null;
        }

        /// <summary>
        /// Поиск DFS
        /// </summary>
        /// <param name="data">Искомое данное</param>
        /// <param name="result">Результат поиска (истина - найдено, ложь - не найдено)</param>
        /// <returns></returns>
        public List<TreeNode<T>> DFS(T data, out bool result)
        {
            List<TreeNode<T>> path = new List<TreeNode<T>>();
            DFS(Root, path, data);
            if (data.CompareTo(path[path.Count - 1].Data) == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return path;
        }

        /// <summary>
        /// Поиск DFS
        /// </summary>
        /// <param name="node">Корень дерева</param>
        /// <param name="result">Путь поиска элемента</param>
        /// <param name="data">Искомое данное</param>
        private void DFS(TreeNode<T> node, List<TreeNode<T>> result, T data)
        {
            if (node != null)
            {
                result.Add(node);
                if (data.CompareTo(node.Data) == 0)
                {
                    return;
                }
                DFS(node.Left, result, data);
                DFS(node.Right, result, data);
            }
        }


        /// <summary>
        /// Поиск BFS
        /// </summary>
        /// <param name="data">Искомый элемент</param>
        /// <param name="result">Результат поиска (истина - найдено, ложь - не найдено)</param>
        /// <returns>Путь поиска элемента</returns>
        public List<TreeNode<T>> BFS(T data, out bool result)
        {
            List<TreeNode<T>> path = new List<TreeNode<T>>();
            path = BFS(Root, data);
            if (data.CompareTo(path[path.Count - 1].Data) == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return path;
        }

        /// <summary>
        /// Поиск BFS
        /// </summary>
        /// <param name="node">Корень дерева</param>
        /// <param name="data">Искомый элемент</param>
        /// <returns>Путь до элемента</returns>
        private List<TreeNode<T>> BFS(TreeNode<T> node, T data)
        {
            List<TreeNode<T>> result = new List<TreeNode<T>>();
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                TreeNode<T> next = queue.Dequeue();
                if (next == null)
                {
                    continue;
                }
                result.Add(next);
                if (data.CompareTo(next.Data) == 0)
                {
                    break;
                }

                foreach (TreeNode<T> children in next.Children)
                {
                    queue.Enqueue(children);
                }
            }
            return result;
        }

        /// <summary>
        /// Вывод двоичного дерева поиска на консоль
        /// </summary>
        public void VisualizeTree()
        {
            char[][] console = InitializeArray(out int width);
            VisualizeNode(Root, 0, width / 2, console, width);
            foreach (char[] row in console)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Заполнение массива информацией об узле 
        /// </summary>
        /// <param name="node">Узел</param>
        /// <param name="row">Строка в массиве, зависит от высоты узла</param>
        /// <param name="column">Порядковый номер по горизонтали узла</param>
        /// <param name="console">Массив для хранения значение узлов дерева, в котором элементы расположены согласно их выводу в консоли</param>
        /// <param name="width">Кол-во элементов нижнего уровня дерева</param>
        private void VisualizeNode(TreeNode<T> node, int row, int column, char[][] console, int width)
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

        /// <summary>
        /// Создание массива для хранения значений узлов дерева, в порядке, котором элементы расположены согласно их выводу в консоли
        /// </summary>
        /// <param name="tree">Корень дерева</param>
        /// <param name="width">Кол-во элементов нижнего уровня</param>
        /// <returns>Кол-во элементов нижнего уровня</returns>
        private char[][] InitializeArray(out int width)
        {
            int height = GetHeight();
            width = (int)Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < height * 2; i++)
            {
                console[i] = new char[COLUMN_WIDTH * width];
            }
            for (int i = 0; i < console.Length; i++)
            {
                for (int j = 0; j < console[i].Length; j++)
                {
                    console[i][j] = ' ';
                }
            }
            return console;
        }




    }
}

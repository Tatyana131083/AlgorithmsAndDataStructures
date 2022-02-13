using System;

namespace Algorithms
{
    public class BinarySearchTree <T> where T : IComparable
    {
        public TreeNode<T> Root { get; set; }
        public int Count { get; set; }


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
            TreeNode<T> node = new TreeNode<T>(){ Data = data, Parent = parent };

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
                    //находим минимальный элемент в левом поддереве
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
            if(root == null)
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

    }
}

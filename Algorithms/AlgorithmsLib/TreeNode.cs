using System.Collections.Generic;


namespace AlgorithmsLib
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode<T> Left
        {
            get { return (TreeNode<T>)Children[0]; }
            set { Children[0] = value; }
        }

        public TreeNode<T> Right
        {
            get { return (TreeNode<T>)Children[1]; }
            set { Children[1] = value; }
        }

        /// <summary>
        /// Конструктор, иницаилизирует список из двух потомков
        /// </summary>
        public TreeNode()
        {
            Children = new List<TreeNode<T>>() { null, null };
        }

        /// <summary>
        /// Определение высоты текущего узла
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = this;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }
            return height;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
        public Node<T> PrevNode { get; set; }

        public Node(T value)
        {
            Value = value;
        }
                                                                                                                                                                        
    }
}

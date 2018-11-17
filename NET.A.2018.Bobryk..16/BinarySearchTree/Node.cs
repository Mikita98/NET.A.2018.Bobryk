using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T>
    {
        public T element { get; set; }
        public Node<T> rightChild { get; set; }
        public Node<T> leftChild { get; set; }

        public Node(T element)
        {
            this.element = element;
        }
    }
}

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
        public Node<T> rightChild;
        public Node<T> leftChild;

        public Node(T element)
        {
            this.element = element;
        }
    }
}

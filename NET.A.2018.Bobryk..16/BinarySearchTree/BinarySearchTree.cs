using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// Generic class represents binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private const int DEFAULTVERSION = 1;

        private Node<T> Root { get; set; }

        private Comparison<T> comparison { get; }

        private bool IsEmpty { get => Root == null; }

        private int Version { get; set; }

        #region Constructors
        /// <summary>
        /// Constructor uses default comparer without input arguments
        /// </summary>
        public BinarySearchTree()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"The {typeof(T)} must immplement IComparable<{typeof(T)}> interface.");
            }

            this.Version = DEFAULTVERSION;
            this.comparison = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Constructor uses input IComparer method
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparison = comparer.Compare;
            this.Version = DEFAULTVERSION;
        }

        /// <summary>
        /// Constructor uses input delegate Comparison
        /// </summary>
        /// <param name="comparison"></param>
        public BinarySearchTree(Comparison<T> comparison)
        {
            this.comparison = comparison;
            this.Version = DEFAULTVERSION;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method check is tree contain input element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            foreach (Node<T> iterator in NodeLeftRight(Root))
            {
                if (Equals(iterator.element,element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Inserts elements in binary tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElement"></param>
        public void Insert(T element)
        {
            if (IsEmpty)
            {
                Root = new Node<T>(element);
            }
            else
            {
                Node<T> root = Root;
                InsertNode(ref root, element);
            }
            Version++;
        }

        /// <summary>
        /// Removes a tree
        /// </summary>
        public void Remove()
        {
            Root = null;
            this.Version = DEFAULTVERSION;
        }

        /// <summary>
        /// Represents Pre-Order of Binary tree(NodeLeftRight)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreOrder() 
            => BaseOrder(NodeLeftRight);

        /// <summary>
        /// Represents In-Order of Binary tree(LeftNodeRight)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrder() 
            => BaseOrder(LeftNodeRight);

        /// <summary>
        /// Represents Post-Order of Binary tree(LeftRightNode)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrder() 
            => BaseOrder(LeftRightNode);

        #endregion  

        #region Private methods
        
        private void InsertNode(ref Node<T> node, T element)
        {
            if (node == null)
            {
                node = new Node<T>(element);
                return;
            }

            if (comparison(element, node.element) < 0)
            {
                InsertNode(ref node.leftChild, element);
            }
            else
            {
                InsertNode(ref node.rightChild, element);
            }
        }

        private IEnumerable<T> BaseOrder(Func<Node<T>, IEnumerable<Node<T>>> orderType )
        {
            IEnumerable<Node<T>> order = orderType.Invoke(Root);
            foreach (Node<T> node in order)
            {
                yield return node.element;
            }
        }

        private IEnumerable<Node<T>> NodeLeftRight(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node;

            if (node.leftChild != null)
            {
                foreach (Node<T> iterator in NodeLeftRight(node.leftChild))
                {
                    yield return iterator;
                }
            }

            if (node.rightChild != null)
            {
                foreach (Node<T> iterator in NodeLeftRight(node.rightChild))
                {
                    yield return iterator;
                }
            }
        }

        private IEnumerable<Node<T>> LeftNodeRight(Node<T> node)
        {
            if (node.leftChild != null)
            {
                foreach (Node<T> iterator in LeftNodeRight(node.leftChild))
                {
                    yield return iterator;
                }
            }

            if (node == null)
            {
                yield break;
            }

            yield return node;

            if (node.rightChild != null)
            {
                foreach (Node<T> iterator in LeftNodeRight(node.rightChild))
                {
                    yield return iterator;
                }
            }
        }

        private IEnumerable<Node<T>> LeftRightNode(Node<T> node)
        {
            if (node.leftChild != null)
            {
                foreach (Node<T> iterator in LeftRightNode(node.leftChild))
                {
                    yield return iterator;
                }
            }

            if (node.rightChild != null)
            {
                foreach (Node<T> iterator in LeftRightNode(node.rightChild))
                {
                    yield return iterator;
                }
            }

            if (node == null)
            {
                yield break;
            }

            yield return node;
        }
        #endregion

        #region IEnumerable impementation
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in InOrder())
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        class Node<T>
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
}

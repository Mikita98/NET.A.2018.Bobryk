using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearchTree.Test.CustomComparers;
using BinarySearchTree.Test.CustomTypes;

namespace BinarySearchTree.Test
{
    [TestFixture]
    public class BinarySearchTest
    {
        [TestCase(new int[] { 9, 8, 5, 2, 7, 0, -46, 24, 56 })]
        [TestCase(new int[] { -68, 43, 22, 79, 14, 0, 0, 0 })]
        public void ComparingIntValues_DefaultCompareAndCustomCompare(int[] array)
        {
            BinarySearchTree<int> first = CreateTree<int>(array);
            BinarySearchTree<int> second = CreateTree<int>(new IntComparer(), array);
            Assert.AreEqual(first, second);
        }

        [TestCase( "feofue", "rgrdg", "1000", "2452300", "123124")]
        [TestCase("one", "two", "tree", "four", "five")]
        public void ComparingStringValues_DefaultCompareAndCustomCompare(params string[] array)
        {
            BinarySearchTree<string> first = CreateTree<string>(array);
            BinarySearchTree<string> second = CreateTree<string>(new CustomComparers.StringComparer(), array);

            Assert.IsFalse(first == second);
        }

        [TestCase(1, 4343, 45, 76, 92, 18, 72, 48)]
        public void ComparingBookValues_DefaultCompareAndCustomCompare(params int[] array)
        {
            List<Book> books = ArrayBookToList(array);
            BinarySearchTree<Book> first = CreateTree<Book>(books);
            BinarySearchTree<Book> second = CreateTree<Book>(new BookComparer(), books);

            Assert.AreEqual(first,second);
        }

        [TestCase(1, 4343, 45, 76, 92, 18, 72, 48)]
        public void ComparingPointValues_DefaultCompareAndCustomCompare(params int[] array)
        {
            List<Point> points = ArrayPointToList(array);
            BinarySearchTree<Point> first = CreateTree<Point>(new PointComparer(),points);
            BinarySearchTree<Point> second = CreateTree<Point>(new PointComparer(), points);
            var list1 = first.PreOrder();
            var list2 = second.PreOrder();
            CollectionAssert.AreEqual(list1.ToArray(), list2.ToArray());
        }

        #region Private methods
        private BinarySearchTree<T> CreateTree<T>(params T[] values)
        {
            BinarySearchTree<T> tree = new BinarySearchTree<T>();
            for (int i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }

            return tree;
        }

        private BinarySearchTree<T> CreateTree<T>(IComparer<T> comparer, params T[] values)
        {
            BinarySearchTree<T> tree = new BinarySearchTree<T>(comparer);
            for (int i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }

            return tree;
        }

        private BinarySearchTree<T> CreateTree<T>(IComparer<T> comparer, IEnumerable<T> list)
        {
            BinarySearchTree<T> tree = new BinarySearchTree<T>(comparer);
            foreach (T iterator in list)
            {
                tree.Insert(iterator);
            }

            return tree;
        }

        private BinarySearchTree<T> CreateTree<T>(IEnumerable<T> list)
        {
            BinarySearchTree<T> tree = new BinarySearchTree<T>();
            foreach (T iterator in list)
            {
                tree.Insert(iterator);
            }

            return tree;
        }

        private List<Book> ArrayBookToList(int[] values)
        {
            List<Book> list = new List<Book>();
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(new Book(values[i]));
            }

            return list;
        }

        private List<Point> ArrayPointToList(int[] values)
        {
            List<Point> list = new List<Point>();
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(new Point(values[i], 1));
            }

            return list;
        }
        #endregion
    }
}

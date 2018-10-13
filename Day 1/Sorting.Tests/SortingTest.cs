using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Tests
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void MergeSortingMethod_LittleUnsortedArray_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new[] { 5, 7, 8, 1, 9 };
            int[] expected = new[] { 1, 5, 7, 8, 9 };

            // Act
            QuckMergeSort.Sorting.MergeSort(actual, 0, actual.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSortingMethod_LittleUnsortedArray_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new[] { 5, 7, 8, 1, 9 };
            int[] expected = new[] { 1, 5, 7, 8, 9 };

            // Act
            QuckMergeSort.Sorting.QuickSort(actual, 0, actual.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSortingMethod_BigUnsortedArray_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[10000000];
            int[] expected = new int[10000000];
            Random rnd = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                actual[i] = rnd.Next(-1000, 1000);
            }

            Array.Copy(actual, expected, actual.Length);
            Array.Sort(expected);

            // Act
            QuckMergeSort.Sorting.QuickSort(actual, 0, actual.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSortingMethod_BigUnsortedArray_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[10000000];
            int[] expected = new int[10000000];
            Random rnd = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                actual[i] = rnd.Next(-1000, 1000);
            }

            Array.Copy(actual, expected, actual.Length);
            Array.Sort(expected);

            // Act
            QuckMergeSort.Sorting.MergeSort(actual, 0, actual.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSortingMethod_OneLengthArray_ReturnArray()
        {
            // Arrange
            int[] actual = new[] { 5 };
            int[] expected = new[] { 5 };

            // Act
            QuckMergeSort.Sorting.QuickSort(actual, 0, actual.Length);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSortingMethod_OneLengthArray_ReturnArray()
        {
            // Arrange
            int[] actual = new[] { 5 };
            int[] expected = new[] { 5 };

            // Act
            QuckMergeSort.Sorting.MergeSort(actual, 0, actual.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

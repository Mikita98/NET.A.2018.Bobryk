using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JaggedSorting;

namespace JaggedSorting.Test
{
    [TestFixture]
    public class JaggedSortingTest
    {
        [TestCase(new int[] { 1, 3, 5, 7, 7 }, new int[] { 4, 8, 6, 10, 3 }, new int[] { -1, 4, 2, 9, 0 })]
        [TestCase(new int[] { 17, 35, 33, 7, 9 }, new int[] { 4, 8, 6, 100, 3 }, new int[] { -1, 0, 53, -7, })]
        [TestCase(null, new int[] { 4, 8, 6, 10, 3 }, null)]
        public void MaxSortingTest_ValidData_ValidResult(int[] array0, int[] array1, int[] array2)
        {
            int[][] array = new int[3][];
            array[0] = array0;
            array[1] = array1;
            array[2] = array2;
            int[][] expected = new int[3][];
            expected[0] = array1;
            expected[1] = array2;
            expected[2] = array0;
            JaggedSorting.MaxValueSorting(ref array);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestCase(new int[] { -100, 4, 2, 9, }, new int[] { -6, 4, 2, 9, }, new int[] { 4, 8, -2, 10, 3 }, new int[] { -1, 3, 5, 7, 7 })]
        [TestCase(new int[] { 9, 4, 2, -100 }, new int[] { -50, 4, 2, 9, }, new int[] { 4, 8, -23, 10, 3 }, new int[] { 0, 3, 5, 7, 7 })]
        [TestCase(null, new int[] { -6, 4, 2, 9, }, new int[] { 4, 8, -2, 10, 3 }, new int[] { -1, 3, 5, 7, 7 })]
        public void MinSortingTest_ValidData_ValidResult(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] array = new int[4][];
            array[0] = array0;
            array[1] = array1;
            array[2] = array2;
            array[3] = array3;
            int[][] expected = new int[4][];
            expected[0] = array3;
            expected[1] = array2;
            expected[2] = array1;
            expected[3] = array0;
            JaggedSorting.MinValueSorting(ref array);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestCase(new int[] { 0, 4, 2, 9, }, new int[] { 234, 4, 46, 9, }, new int[] { 4, 8, 2, 460, 3 }, new int[] { 1, 1000, 5, 7, 7 })]
        [TestCase(new int[] { 0, -4, 2, -9, }, new int[] { 0, 4, 46, 9, }, new int[] { 4, 8, 2, 460, 3 }, new int[] { 1, 1000, 5, 7, 7 })]
        [TestCase(null, null, new int[] { 4, 8, 2, 460, 3 }, new int[] { 1, 1000, 5, 7, 7 })]
        public void SumSortingTest_ValidData_ValidResult(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] array = new int[4][];
            array[0] = array0;
            array[1] = array1;
            array[2] = array2;
            array[3] = array3;
            int[][] expected = new int[4][];
            expected[0] = array3;
            expected[1] = array2;
            expected[2] = array1;
            expected[3] = array0;
            JaggedSorting.SumValueSorting(ref array);
            CollectionAssert.AreEqual(array, expected);
        }
    }
}

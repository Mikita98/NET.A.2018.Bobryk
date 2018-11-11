using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinarySearch.Test
{
    [TestFixture]
    public class BinarySeachTest
    {
        [TestCase (new int[10] {0, 1, 2, 3, 5, 19, 45, 78, 90, 100}, 5, ExpectedResult = 4)]
        [TestCase(new int[10] { -7, -1, 0, 3, 5, 19, 79, 89, 90, 100 }, -1, ExpectedResult = 1)]
        public int BinarySearchInt_ValidData_ValidResult(int[] array, int key)
        {
            BinarySearch binarySearch = new BinarySearch();
            return binarySearch.Search<int>(array, key, new IntCopmarer());
        }

        [TestCase(new double[10] { 0, 1, 2, 3, 5.0, 19, 45, 78, 90, 100 }, 5.0, ExpectedResult = 4)]
        [TestCase(new double[10] { -7.6, -1.0, 0.008, 3.7653, 5.4, 19, 79, 89, 90, 100 }, 3.6, ExpectedResult = 3)]
        public int BinarySearchDouble_ValidData_ValidResult(double[] array, double key)
        {
            BinarySearch binarySearch = new BinarySearch();
            return binarySearch.Search<double>(array, key, new DoubleComparer());
        }
    }
}

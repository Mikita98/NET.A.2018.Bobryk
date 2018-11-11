using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearch
    {
        /// <summary>
        /// Seacrh number in array
        /// </summary>
        /// <param name="array">Array where will searh</param>
        /// /// <param name="key">Number need to find</param>
        /// /// <param name="comparer">Algoritm to compare</param>
        /// <exception cref="ArgumentException"> if numbers null </exception>
        public int Search<T>( T[] array, T key, IComparer<T> comparer)
        {
            int left = 0;
            int right = array.Length;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (comparer.Compare(array[mid], key) == 0)
                    return mid;

                if (comparer.Compare(array[mid], key) == 1)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -(1 + left);
        }

        private  void CheckData<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentException(nameof(array) + "can't be null!");
            }

            if (key == null)
            {
                throw new ArgumentException(nameof(key) + "can't be null!");
            }

            if (comparer == null)
            {
                throw new ArgumentException(nameof(comparer) + "can't be null!");
            }
        }
    }
}

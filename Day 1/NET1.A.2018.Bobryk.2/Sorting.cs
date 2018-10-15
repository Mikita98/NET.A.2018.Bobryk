using System;

namespace QuckMergeSort
{
    /// <summary>
    /// This is Sorting class that includes MergeSort and QuickSort
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// The MergeSort method.
        /// </summary>
        /// <param arr>
        /// The source array.
        /// </param>
        /// <param start>
        /// Starting position to sort.
        /// </param>
        /// <param end>
        /// Ending position to sort.
        /// </param>
        public static void MergeSort(int[] arr, int start, int end)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if ((arr.Length == 1) || ((start == 0) && (end == 0)) || (start == end))
            {
                return;
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException(nameof(arr));
            }

            Merge(arr, start, end);
        }

        public static void MergeSort(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length == 1)
            {
                return;
            }

            Merge(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// The QuickSort method, using quicksorting method. From start point to end point.
        /// </summary>
        /// <param elements>
        /// The source array.
        /// </param>
        /// <param left>
        /// Starting position to sort.
        /// </param>
        /// <param right>
        /// Ending position to sort.
        /// </param>
        public static void QuickSort(int[] elements, int left, int right)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if ((elements.Length == 1) || ((left == 0) && (right == 0)) || (left == right))
            {
                return;
            }

            if (left > right)
            {
                throw new ArgumentOutOfRangeException(nameof(elements));
            }

            Quick(elements, left, right);
        }

        /// <summary>
        /// The QuickSort method, using quicksorting method. Sort al array
        /// </summary>
        /// <param elements>
        /// The source array.
        /// </param>
        public static void QuickSort(int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (elements.Length == 1)
            {
                return;
            }

            Quick(elements, 0, elements.Length - 1);
        }

        private static void Quick(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quick(elements, left, j);
            }

            if (i < right)
            {
                Quick(elements, i, right);
            }
        }

        private static void Merge(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                Merge(arr, start, middle);
                Merge(arr, middle + 1, end);
                MergeHalves(arr, start, middle, end);
            }
        }

        private static void MergeHalves(int[] array, int start, int middle, int end)
        {
            int leftlength = middle - start + 1;
            int rightlength = end - middle;
            int[] leftAr = new int[leftlength];
            int[] rightAr = new int[rightlength];

            int i, j;

            for (i = 0; i < leftlength; ++i)
            {
                leftAr[i] = array[start + i];
            }

            for (j = 0; j < rightlength; ++j)
            {
                rightAr[j] = array[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = start;

            while (i < leftlength && j < rightlength)
            {
                if (leftAr[i] <= rightAr[j])
                {
                    array[k] = leftAr[i];
                    i++;
                }
                else
                {
                    array[k] = rightAr[j];
                    j++;
                }

                k++;
            }

            FilArray(ref k, ref i, leftlength, array, leftAr);
            FilArray(ref k, ref j, rightlength, array, rightAr);
        }

        private static void FilArray(ref int k, ref int i, int length, int[] array, int[] halfArray)
        {
            while (i < length)
            {
                array[k] = halfArray[i];
                i++;
                k++;
            }
        }
    }
}

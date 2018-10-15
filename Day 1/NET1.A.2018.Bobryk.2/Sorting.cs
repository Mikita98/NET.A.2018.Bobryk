using System;

namespace QuckMergeSort
{
    /// <summary>
    /// This is Sorting class that incules MergeSort and QuickSort
    /// </summary>
    public class Sorting
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
            if (arr.Length == 1)
            {
                return;
            }

            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(arr, start, middle);
                MergeSort(arr, middle + 1, end);
                MergeHalves(arr, start, middle, end);
            }
        }


        /// <summary>
        /// The QuickSort method.
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
            if(elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (elements.Length == 1)
            {
                return;
            }
 
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
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
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

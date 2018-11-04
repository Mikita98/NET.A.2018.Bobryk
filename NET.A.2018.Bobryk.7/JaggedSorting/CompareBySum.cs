using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorting
{
    public class CompareBySum : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
        {
            if (first == second)
            {
                return 0;
            }
            else if (first == null)
            {
                return -1;
            }
            else if (second == null)
            {
                return 1;
            }

            int firstSum = first.Sum();
            int secondSum = second.Sum();

            if ( firstSum == secondSum)
            {
                return 0;
            }
            else if (firstSum > secondSum)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}

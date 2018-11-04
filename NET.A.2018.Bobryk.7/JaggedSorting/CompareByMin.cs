using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorting
{
    public class CompareByMin : IComparer<int[]>
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

            int firstMin = first.Sum();
            int secondMin = second.Sum();

            if (firstMin == secondMin)
            {
                return 0;
            }
            else if (firstMin > secondMin)
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

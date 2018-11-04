using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorting
{
    public class CompareByMax : IComparer<int[]>
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

            int firstMax = first.Max();
            int secondMax = second.Max();

            if (firstMax == secondMax)
            {
                return 0;
            }
            else if (firstMax > secondMax)
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

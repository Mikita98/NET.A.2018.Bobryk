using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class IntCopmarer : IComparer<int>
    {
        public int Compare(int value1, int value2)
        {
            if (value1 < value2)
            {
                return -1;
            }
            else if (value1 > value2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

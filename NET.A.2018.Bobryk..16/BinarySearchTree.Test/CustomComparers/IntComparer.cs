using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test.CustomComparers
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            if (first > second)
            {
                return 1;
            }
            else if (first < second)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

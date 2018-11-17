using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test.CustomComparers
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            if ((first.Length > second.Length) || (first != null && second == null))
            {
                return 1;
            }
            else if ((first.Length < second.Length) || (first == null && second != null))
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

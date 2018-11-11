using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{ 
    /// <summary>
    /// Impemenation of IComparer
    /// </summary>
    public class DoubleComparer : IComparer<double>
    {
        private double eps = 0.00001;

        /// <summary>
        /// Compare 2 int values
        /// </summary>
        /// <param name="value1">first number to compare</param>
        /// /// <param name="value2">seconf number to compare</param>
        public int Compare(double value1, double value2)
        {
            if ((value1 - value2) < 0)
            {
                return -1;
            }
            else if ((value1 - value2) > eps)
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

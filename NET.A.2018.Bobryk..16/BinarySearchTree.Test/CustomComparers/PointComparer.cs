using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree.Test.CustomTypes;

namespace BinarySearchTree.Test.CustomComparers
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point point1, Point point2)
        {
            if ((point1.x * point1.y > point2.x * point2.y) || (point1 != null && point2 == null))
            {
                return 1;
            }
            else if ((point1.x * point1.y < point2.x * point2.y) || (point1 == null && point2 != null))
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

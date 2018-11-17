using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree.Test.CustomTypes;

namespace BinarySearchTree.Test.CustomComparers
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            if ((book1.pages > book2.pages) || (book1 != null && book2 == null))
            {
                return 1;
            }
            else if ((book1.pages < book2.pages) || (book1 == null && book2 != null))
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

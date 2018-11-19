using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test.CustomTypes
{
    public class Book : IComparable<Book>
    {
        public int pages { get; set; }

        public Book(int pages)
        {
            this.pages = pages;
        }

        public int CompareTo(Book other)
        {
            return pages.CompareTo(other.pages);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test.CustomTypes
{
    public class Book
    {
        public int pages { get; set; }

        public Book(int pages)
        {
            this.pages = pages;
        }

        public override bool Equals(object obj)
        {
            Book otherBook = obj as Book;
            if (this.pages == otherBook.pages)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

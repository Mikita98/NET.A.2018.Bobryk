using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTypes
{
    public class ElementsIEquatable
    {
        public ElementsIEquatable(int id, string count)
        {
            Id = id;
            Count = count;
        }

        public int Id { get; set; }

        public string Count { get; set; }



        public bool Equals(ElementsIEquatable elements)
        { 
            return elements.Count == Count && elements.Id == Id;
        }
    }
}

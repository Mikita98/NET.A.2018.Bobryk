using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTypes
{
    public class Elements
    {
        public Elements(int id, string count)
        {
            Id = id;
            Count = count;
        }

        public int Id { get; set; }

        public string Count { get; set; }
    }
}

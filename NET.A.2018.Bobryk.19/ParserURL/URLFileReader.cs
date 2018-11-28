using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParserURL
{
    public class URLFileReader : IRepository<string>
    {
        private IEnumerable<string> elements { get; set; }

        public URLFileReader(string filepath)
        {
            ReadFile(filepath);
        }

        public void ReadFile(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("File not exists!");
            }

            elements =  File.ReadLines(filepath);
        }

        public IEnumerable<string> GetElements()
        {
            if (elements == null)
            {
                throw new ArgumentException("Elements can't be null!");
            }

            return elements;
        }
    }
}

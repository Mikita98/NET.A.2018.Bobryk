using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParserURL
{
    /// <summary>
    /// Read file with adresess
    /// </summary>
    public class URLFileReader : IRepository<string>
    {
        private IEnumerable<string> elements { get; set; }

        /// <summary>
        /// Constructor that recieve filepath for reading
        /// </summary>
        /// <param name="filepath"></param>
        public URLFileReader(string filepath)
        {
            ReadFile(filepath);
        }

        /// <summary>
        /// Read file and return List of string
        /// </summary>
        /// <param name="filepath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public void ReadFile(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("File not exists!");
            }

            elements =  File.ReadLines(filepath);
        }

        /// <summary>
        /// Interface method for getting elements from Repository
        /// </summary>
        /// <returns></returns>
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

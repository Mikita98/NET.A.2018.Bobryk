using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    /// <summary>
    /// Imlements composite pattern
    /// </summary>
    public class Provider : IProvider
    {
        private List<IProvider> children = new List<IProvider>();

        public void Add(IProvider provider)
        {
            children.Add(provider);
        }

        public void Remove(IProvider provider)
        {
            children.Remove(provider);
        }

        public bool Validate(string path)
        {
            bool result = true;

            foreach (IProvider provider in children)
            {
                result = result || provider.Validate(path);
            }

            return result;
        }
    }
}

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
    public class Validator : IValidator<string>
    {
        private List<IValidator<string>> children = new List<IValidator<string>>();

        public void Add(IValidator<string> provider)
        {
            children.Add(provider);
        }

        public void Remove(IValidator<string> provider)
        {
            children.Remove(provider);
        }

        public bool Validate(string path)
        {
            bool result = true;

            foreach (IValidator<string> provider in children)
            {
                result = result || provider.Validate(path);
            }

            return result;
        }
    }
}

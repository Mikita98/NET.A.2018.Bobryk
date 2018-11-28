using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    /// <summary>
    /// Implements Composite pattern
    /// </summary>
    public interface IProvider
    {
        void Add(IProvider provider);

        void Remove(IProvider provider);

        bool Validate(string adress);
    }
}

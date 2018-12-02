using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    /// <summary>
    /// Implements IRepository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProvider<T>
    {
        IEnumerable<T> GetElements();
    }
}

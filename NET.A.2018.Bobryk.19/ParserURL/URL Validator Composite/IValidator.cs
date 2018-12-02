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
    public interface IValidator<in TSourse>
    {
        bool Validate(TSourse adress);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    public interface IParser<in TSourse, out TResult>
    {
        TResult Parse(TSourse sourse);
    }
}

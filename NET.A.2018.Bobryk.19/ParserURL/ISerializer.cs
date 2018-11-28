using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    public interface ISerializer<U>
    {
        void Serialize(U data, string path);
    }
}

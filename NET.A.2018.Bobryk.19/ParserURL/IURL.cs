using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    public interface IURL<T>
    {
        T HostName { get; set; }

        List<T> Segments { get; set; }

        Dictionary<T, T> Parameters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParserURL
{
    public class URL : IURL<string>
    {
        public string HostName { get; set; }

        public List<string> Segments { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}

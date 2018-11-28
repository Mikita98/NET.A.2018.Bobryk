using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace ParserURL
{
    /// <summary>
    /// 
    /// </summary>
    public class URLFileSerializer : ISerializer<List<URL>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void Serialize(List<URL> list, string path)
        {
            if (!File.Exists(path))
            {
                throw new DirectoryNotFoundException("Invalid directory path!");
            }

            var xml = new XElement("urlAddresses",
                list.Select(x => new XElement("urlAddress",
                new XElement("host",
                new XAttribute("name", x.HostName)),
                new XElement("uri", x.Segments.Select(y =>
                new XElement("segment", y))),
                new XElement("parameters", x.Parameters?.Select(y =>
                new XElement("parameter",
                new XAttribute("value", y.Value),
                new XAttribute("key", y.Key)))))));
            XDocument xDoc = new XDocument(xml);
            xDoc.Save(path);
        }
    }
}

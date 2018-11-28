using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserURL;

namespace ParserURl.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Epam\Test.txt";

            URLFileReader fileReader = new URLFileReader(filePath);

            URLParser parser = new URLParser();

            URLFileSerializer serializer = new URLFileSerializer();

            serializer.Serialize(parser.Parse(fileReader.GetElements()), @"D:\Epam\output.xml");
        }
    }
}

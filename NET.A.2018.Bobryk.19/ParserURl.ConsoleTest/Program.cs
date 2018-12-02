using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserURL;
using Ninject.Modules;
using Ninject;

namespace ParserURL.ConsoleTest
{
    class Program
    {
        /// <summary>
        /// Load Ninject dependecies
        /// </summary>
        public class ConfigurationModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IProvider<string>>().To<URLFileProvider>().WithConstructorArgument("filepath", @"D:\Epam\Test.txt");
                Bind<IValidator<string>>().To<URLValidator>();
                Bind<IParser<IEnumerable<string>, List<URL>>>().To<URLParser>().WithConstructorArgument("validator", new URLValidator());
                Bind<ISerializer<List<URL>>>().To<URLFileSerializer>().WithConstructorArgument("path", @"D:\Epam\output.xml");
            }
        }

        static void Main(string[] args)
        {
            /*string filePath = @"D:\Epam\Test.txt";

            URLFileProvider fileReader = new URLFileProvider(filePath);

            URLParser parser = new URLParser(new URLValidator());

            URLFileSerializer serializer = new URLFileSerializer(@"D:\Epam\output.xml");

            serializer.Serialize(parser.Parse(fileReader.GetElements()));*/


            IKernel kernel = new StandardKernel(new ConfigurationModule());

            IProvider<string> provider = kernel.Get<IProvider<string>>();

            IValidator<string> validator = kernel.Get<IValidator<string>>();

            IParser<IEnumerable<string>, List<URL>> parser = kernel.Get<IParser<IEnumerable<string>, List<URL>>>();

            ISerializer<List<URL>> serializer = kernel.Get<ISerializer<List<URL>>>();

            serializer.Serialize(parser.Parse(provider.GetElements()));

            Console.WriteLine("Succesfuly serialize!");

            Console.ReadLine();
        }
    }
}

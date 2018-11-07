using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocks.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            OtherSubscriber otherSubscriber = new OtherSubscriber();
            AnotherSubscriber anotherSubscriber = new AnotherSubscriber();

            subscriber.Register(publisher);
            otherSubscriber.Register(publisher);
            anotherSubscriber.Register(publisher);

            publisher.Publish(5000);

            Console.ReadKey();
        }
    }
}

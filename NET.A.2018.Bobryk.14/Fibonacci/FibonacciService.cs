using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Represent class that implement IFibonacci
    /// </summary>
    public class FibonacciService : IFibonacci
    {
        public List<long> FibonacciByLength(int length)
        {
            FibonacciLength fibonacci = new FibonacciLength();
            return fibonacci.Generate(length);
        }

        public List<long> FibonacciByValue(long number)
        {
            FibonacciValue fibonacci = new FibonacciValue();
            return fibonacci.Generate(number);
        }
    }
}

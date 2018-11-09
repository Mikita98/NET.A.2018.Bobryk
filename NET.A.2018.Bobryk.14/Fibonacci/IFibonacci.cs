using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Represent interface to calculate fibonacci numbers
    /// </summary>
    public interface IFibonacci
    {
        List<long> FibonacciByLength(int length);

        List<long> FibonacciByValue(long number);
    }
}

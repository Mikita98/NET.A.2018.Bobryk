using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    /// <summary>
    /// Adapter that implement generic interface ITransformer for Bits transforming
    /// </summary>
    public class BitsTransformerAdapter : ITransformer<double, string>
    {
        public string Transform(double number)
            => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);
    }
}

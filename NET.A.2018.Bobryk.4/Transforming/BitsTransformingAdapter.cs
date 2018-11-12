using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    /// <summary>
    /// Adapter that implement NOT generic interface ITransforming for Bits transforming
    /// </summary>
    public class BitsTransformingAdapter : ITransforming
    {
        public string Transform(double number)
         => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);
    }
}

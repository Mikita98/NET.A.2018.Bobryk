using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public class BitsTransformingAdapter : ITransforming
    {
        public string Transform(double number)
         => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);
    }
}

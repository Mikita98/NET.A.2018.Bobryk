using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public class BitsTransformerAdapter :ITransformer<double, string>
    {
        public string Transform(double number)
            => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public interface ITransforming
    {
        string Transform(double number);
    }

    public class DoubleToWords: ITransforming
    {
        public string Transform(double number) => TransformingToWords.TransformToWords(number);
    }

    public class DoubleToBits : ITransforming
    {
        public string Transform(double number) => DoubleBitsToString.DoubleBitsToString.DoubleToString(number);
    }
}

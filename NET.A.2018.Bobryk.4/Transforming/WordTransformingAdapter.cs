using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public class WordTransformingAdapter : ITransforming
    {
        public string Transform(double number)
            => TransformingToWords.TransformToWords(number);
    }
}

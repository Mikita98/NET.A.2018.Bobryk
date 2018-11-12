using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    /// <summary>
    /// Adapter that implement NOT generic interface ITransforming for Word transforming
    /// </summary>
    public class WordTransformingAdapter : ITransforming
    {
        public string Transform(double number)
            => TransformingToWords.TransformToWords(number);
    }
}

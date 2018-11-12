using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    /// <summary>
    /// Adapter that implement generic interface ITransformer for Word transforming
    /// </summary>
    public class WordTransformerAdapter : ITransformer<double, string>
    {
        public string Transform(double number)
         => TransformingToWords.TransformToWords(number);
    } 
}

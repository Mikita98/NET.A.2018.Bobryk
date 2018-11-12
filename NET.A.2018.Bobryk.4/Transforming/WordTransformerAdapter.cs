using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    public class WordTransformerAdapter : ITransformer<double, string>
    {
        public string Transform(double number)
         => TransformingToWords.TransformToWords(number);
    } 
}

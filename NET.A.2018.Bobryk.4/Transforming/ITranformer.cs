using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforming
{
    /// <summary>
    /// Generic Interface for transforming
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ITransformer<TSource, TResult>
    {
        TResult Transform(TSource number);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Validators
{
    public interface IValidator<in TSource>
    {
        bool Validate(TSource source);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.SumManager
{
    public interface IMatrixAdder<T>
    {
        T Sum(T value1, T value2);
    }
}

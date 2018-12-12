using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.SumManager
{
    public interface IMatrixAdder<T>
    {
        Matrix<T> Sum(Matrix<T> value1, Matrix<T> value2);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Validators;

namespace Matrix
{
    public abstract class Matrix<T>
    {
        /// <summary>
        /// size of columns and rows
        /// </summary>
        public int Number { get; protected set; }

        protected IValidator<T[,]> validator;
        
        public event EventHandler<ChangingElementEventArgs> ChangeElement = delegate { };

        /// <summary>
        /// Indexer fo matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public abstract T this[int row, int col]
        { get; set; }

        protected virtual void OnChangeElement(int row, int col)
        {
            this.ChangeElement?.Invoke(this, new ChangingElementEventArgs(row, col));
        }
            
        public abstract void InsertElement(int row, int col, T value);

        protected  void CheckValue(int row, int col)
        {
            if (row > this.Number || row < 0)
            {
                throw new ArgumentException($"Value {row} must be between zero and {this.Number}!");
            }

            if (col > this.Number || col < 0)
            {
                throw new ArgumentException($"Value {col} must be between zero and {this.Number}!");
            }
        }


        public abstract void CheckMatrix();

        protected void CheckValidator(IValidator<T[,]> validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("Validator can't be null!");
            }
        }

        /// <summary>
        /// Class with info about event
        /// </summary>
        public class ChangingElementEventArgs : EventArgs
        {
            /// <summary>
            /// Create instanse of ChangingElementEventArgs
            /// </summary>
            /// <param name="row">
            /// Row of matrix.
            /// </param>
            /// <param name="col">
            /// Column of matrix.
            /// </param>
            public ChangingElementEventArgs(int row, int col)
            {
                this.Col = col;
                this.Row = row;
            }

            /// <summary>
            /// Gets value of row in matrix.
            /// </summary>
            public int Row { get; }

            /// <summary>
            /// Gets value of col in matrix.
            /// </summary>
            public int Col { get; }
        }
    }
}

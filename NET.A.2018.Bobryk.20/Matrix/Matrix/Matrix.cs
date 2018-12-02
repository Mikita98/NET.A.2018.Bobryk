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
        public int Number { get; }

        protected T[,] matrix { get; set; }

        protected IValidator<T[,]> validator;

        /// <summary>
        /// Constructor that takes new size of matrix and validator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="validator"></param>
        public Matrix(int number, IValidator<T[,]> validator)
        {
            CheckValidator(validator);

            this.Number = number;
            this.matrix = new T[Number, Number];
            this.validator = validator;
        }

        /// <summary>
        /// Constructor that takes new matrix and validator
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="validator"></param>
        public Matrix(T[,] matrixAnother, IValidator<T[,]> validator)
        {
            CheckValidator(validator);
            this.validator = validator;
            CheckMatrix(matrixAnother);

            this.Number = (int)Math.Sqrt(matrixAnother.Length);
            this.matrix = matrixAnother;
        }

        public event EventHandler<ChangingElementEventArgs> ChangeElement = delegate { };

        /// <summary>
        /// Indexer fo matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public T this[int row, int col]
        {
            get
            {
                this.CheckValue(row, col);

                return this.matrix[row, col];
            }

            set
            {
                this.CheckValue(row, col);

                this.InsertElement(row, col, value);

                this.OnChangeElement(row, col);
            }
        }

        protected virtual void OnChangeElement(int row, int col)
        {
            this.ChangeElement?.Invoke(this, new ChangingElementEventArgs(row, col));
        }
            
        public abstract void InsertElement(int row, int col, T value);

        private void CheckValue(int row, int col)
        {
            if (row < 0 || row > this.Number)
            {
                throw new ArgumentException("Number of rows is invalid");
            }

            if (col < 0 || col > this.Number)
            {
                throw new ArgumentException("Number of columns is invalid");
            }
        }

        protected void CheckMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix can't be null!");
            }

            if (!validator.Validate(matrix))
            {
                throw new ArgumentException("Matrix is invalid!");
            }
        }

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

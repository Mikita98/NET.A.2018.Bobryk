using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Matrix.Matrix;
using Matrix.Validators;
using Matrix.SumManager;

namespace Matrix.Test
{
    [TestFixture]
    public class MatrixTesting
    {
        [Test]
        public void IntSumTestingTwoSquareMatrix_ValidData_ValidResult()
        {
            int[,] array1 = new int[5, 5] { { 1, 2, 3, 4, 5 }, 
                                            { 1, 2, 3, 4, 5 }, 
                                            { 1, 2, 3, 4, 5 }, 
                                            { 1, 2, 3, 4, 5 }, 
                                            { 1, 2, 3, 4, 5 } };

            int[,] array2 = new int[5, 5] { { 1, 0, 0, 0, 0 },
                                            { 0, 2, 0, 0, 0 },
                                            { 0, 0, 3, 0, 0 },
                                            { 0, 0, 0, 4, 0 },
                                            { 0, 0, 0, 0, 5 } };

            int[,] expected = new int[5, 5]
                                          { { 2, 2, 3, 4, 5 },
                                            { 1, 4, 3, 4, 5 },
                                            { 1, 2, 6, 4, 5 },
                                            { 1, 2, 3, 8, 5 },
                                            { 1, 2, 3, 4, 10 } };

            SquareValidator<int> validator1 = new SquareValidator<int>();
            DiagonalValidator<int> validator2 = new DiagonalValidator<int>();

            SquareMatrix<int> matrix1 = new SquareMatrix<int>(array1, validator1);
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(array2, validator2);

            IntMatrixAdder matrixAdder = new IntMatrixAdder(validator1);

            int[,] actual = matrixAdder.Sum(array1, array2);

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void IsMatrixDiagonall_InalidMatrix_ArgumentExeption()
        {
            int[,] array1 = new int[5, 5] { { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 } };
            DiagonalValidator<int> validator = new DiagonalValidator<int>();

            Assert.Throws<ArgumentException>( () => new DiagonalMatrix<int>(array1, validator));
        }

        [Test]
        public void IsMatrixSummetrical_InalidMatrix_ArgumentExeption()
        {
            int[,] array1 = new int[5, 5] { { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 },
                                            { 1, 2, 3, 4, 5 } };
            SymmetricalValidator<int> validator = new SymmetricalValidator<int>();

            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(array1, validator));
        }

        [Test]
        public void IsMatrixSquare_InalidMatrix_ArgumentExeption()
        {
            int[,] array1 = new int[5, 4] { { 1, 2, 3, 4,},
                                            { 1, 2, 3, 4,},
                                            { 1, 2, 3, 4,},
                                            { 1, 2, 3, 4,},
                                            { 1, 2, 3, 4,} };
            SquareValidator<int> validator = new SquareValidator<int>();

            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(array1, validator));
        }

        [Test]
        public void Indexator_ValideIndexes_ChangedElement()
        {
            int[,] array = new int[5, 5] { { 1, 0, 0, 0, 0 },
                                            { 0, 2, 0, 0, 0 },
                                            { 0, 0, 3, 0, 0 },
                                            { 0, 0, 0, 4, 0 },
                                            { 0, 0, 0, 0, 5 } };

            SymmetricalValidator<int> validator = new SymmetricalValidator<int>();
            Matrix<int> matrix = new SymmetricalMatrix<int>(array, validator);

            matrix[1, 1] = 5;

            Assert.AreEqual(5, matrix[1, 1]);
        }
    }
}

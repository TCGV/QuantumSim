using System.Collections.Generic;
using System.Numerics;
using Tcgv.QuantumSim.Data;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Operations
{
    public abstract class BinaryOperation
    {
        public void Apply(Qubit q1, Qubit q2)
        {
            Qubit.Combine(q1, q2);
            q1.V.MultiplyBy(this, q1.Id, q2.Id);
        }

        public Complex[,] GetMatrix(int bitLen, int bit1Pos, int bit2Pos)
        {
            var matrix = GetMatrix();

            if (bitLen > 2)
            {
                var table = CalculateTable(matrix);
                var mLen = (1 << bitLen);
                matrix = new Complex[mLen, mLen];

                for (int i = 0; i < mLen; i++)
                {
                    var x =
                        (BinaryUtility.HasBit(i, bit1Pos) ? 2 : 0) +
                        (BinaryUtility.HasBit(i, bit2Pos) ? 1 : 0);

                    var y = table[x];

                    var j = BinaryUtility.SetBit(
                        i, bit1Pos, BinaryUtility.HasBit(y, 1)
                    );
                    j = BinaryUtility.SetBit(
                        j, bit2Pos, BinaryUtility.HasBit(y, 0)
                    );

                    matrix[i, j] = Complex.One;
                    matrix[j, i] = Complex.One;
                }
            }

            return matrix;
        }

        protected abstract Complex[,] GetMatrix();

        private Dictionary<int, int> CalculateTable(Complex[,] matrix)
        {
            var bitLen = matrix.GetLength(0);
            var table = new Dictionary<int, int>();
            for (int i = 0; i < bitLen; i++)
            {
                var vector = AlgebraUtility.IntToVector(bitLen, i);
                var result = AlgebraUtility.Multiply(matrix, vector);
                var j = AlgebraUtility.VectorToInt(result);
                table.Add(i, j);
            }
            return table;
        }
    }
}

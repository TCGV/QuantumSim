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
            q1.S.MultiplyBy(this, q1.Id, q2.Id);
        }

        public Complex[,] GetMatrix(int bitLen, int bit1Pos, int bit2Pos)
        {
            var matrix = GetMatrix();
            var table = AlgebraUtility.LookupTable(matrix);

            var mLen = (1 << bitLen);
            matrix = new Complex[mLen, mLen];

            for (int i = 0; i < mLen; i++)
            {
                var x =
                    (BinaryUtility.HasBit(i, bit1Pos) ? 2 : 0) +
                    (BinaryUtility.HasBit(i, bit2Pos) ? 1 : 0);

                foreach (var y in table[x])
                {
                    var j = BinaryUtility.SetBit(
                        i, bit1Pos, BinaryUtility.HasBit(y.Key, 1)
                    );
                    j = BinaryUtility.SetBit(
                        j, bit2Pos, BinaryUtility.HasBit(y.Key, 0)
                    );

                    matrix[i, j] = y.Value;
                    matrix[j, i] = y.Value;
                }
            }

            return matrix;
        }

        protected abstract Complex[,] GetMatrix();
    }
}

using System.Numerics;
using Tcgv.QuantumSim.Data;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Operations
{
    public abstract class UnaryOperation
    {
        public void Apply(Qubit q)
        {
            q.S.MultiplyBy(this, q.Id);
        }

        public Complex[,] GetMatrix(int bitLen, int bitPos)
        {
            var matrix = GetMatrix();

            if (bitLen > 1)
            {
                var table = AlgebraUtility.LookupTable(matrix);
                var mLen = (1 << bitLen);
                matrix = new Complex[mLen, mLen];

                for (int i = 0; i < mLen; i++)
                {
                    var x =
                        (BinaryUtility.HasBit(i, bitPos) ? 1 : 0);

                    foreach (var y in table[x])
                    {
                        var j = BinaryUtility.SetBit(
                            i, bitPos, BinaryUtility.HasBit(y.Key, 0)
                        );

                        matrix[i, j] = y.Value;
                        matrix[j, i] = y.Value;
                    }
                }
            }

            return matrix;
        }

        protected abstract Complex[,] GetMatrix();
    }
}

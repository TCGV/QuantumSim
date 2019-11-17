using System;
using System.Numerics;
using Tcgv.QuantumSim.Data;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Operations
{
    public abstract class UnaryOperation
    {
        public void Apply(Qubit q)
        {
            q.V.MultiplyBy(this, q.Id);
        }

        public Complex[,] GetMatrix(int bitLen, int bitPos)
        {
            var matrix = GetMatrix();

            if (bitPos > 0)
                matrix = AlgebraUtility.TensorProduct(
                        AlgebraUtility.Identity((int)Math.Pow(2, bitPos)), matrix
                    );

            var trailingBits = bitLen - bitPos - 1;
            if (trailingBits > 0)
                matrix = AlgebraUtility.TensorProduct(
                        matrix, AlgebraUtility.Identity((int)Math.Pow(2, trailingBits))
                    );

            return matrix;
        }

        protected abstract Complex[,] GetMatrix();
    }
}

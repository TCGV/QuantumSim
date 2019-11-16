using System.Numerics;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Data
{
    public class Qubit
    {
        public Qubit(bool b)
        {
            SetVec(
                 new Quvec(new QPoint(b)),
                 0
            );
        }

        public Quvec V { get; private set; }

        internal void SetVec(Quvec v, int pos)
        {
            V = v;
            this.pos = pos;
        }

        public void MultiplyBy(Complex[,] matrix)
        {
            var l = V.GetLength();
            if (l > matrix.GetLength(0))
            {
                if (pos > 0)
                    matrix = AlgebraUtility.TensorProduct(
                            AlgebraUtility.Identity(pos * 2), matrix
                        );
                if (pos + 1 < l / 2)
                    matrix = AlgebraUtility.TensorProduct(
                            matrix, AlgebraUtility.Identity((l / 2 - pos - 1) * 2)
                        );
            }
            V.MultiplyBy(matrix);
        }

        public bool Measure()
        {
            return V.Measure(pos);
        }

        private int pos;

        private static int counter = 0;
    }
}

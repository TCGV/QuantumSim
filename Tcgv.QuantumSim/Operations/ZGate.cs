using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class ZGate : UnaryOperation
    {
        protected override Complex[,] GetMatrix()
        {
            return z_matrix;
        }

        private readonly Complex[,] z_matrix = new Complex[,]
        {
            { 1, 0 },
            { 0, -1 }
        };
    }
}

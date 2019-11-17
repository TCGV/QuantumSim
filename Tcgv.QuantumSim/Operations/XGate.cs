using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class XGate : UnaryOperation
    {
        protected override Complex[,] GetMatrix()
        {
            return x_matrix;
        }

        private readonly Complex[,] x_matrix = new Complex[,]
        {
            { 0, 1 },
            { 1, 0 }
        };
    }
}

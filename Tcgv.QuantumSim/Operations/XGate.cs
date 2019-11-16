using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class XGate : UnaryOperation
    {
        public override void Apply(Qubit q)
        {
            q.MultiplyBy(x_matrix);
        }

        private readonly Complex[,] x_matrix = new Complex[,]
        {
            { 0, 1 },
            { 1, 0 }
        };
    }
}

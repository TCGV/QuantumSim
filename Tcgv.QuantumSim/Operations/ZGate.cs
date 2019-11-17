using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class ZGate : UnaryOperation
    {
        public override void Apply(Qubit q)
        {
            q.V.MultiplyBy(z_matrix, q.Id);
        }

        private readonly Complex[,] z_matrix = new Complex[,]
        {
            { 1, 0 },
            { 0, -1 }
        };
    }
}

using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class CZGate : BinaryOperation
    {
        public override void Apply(Qubit q1, Qubit q2)
        {
            Qubit.Combine(q1, q2);
            q1.V.MultiplyBy(cz_matrix, q1.Id, q2.Id);
        }

        private readonly Complex[,] cz_matrix = new Complex[,]
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, -1 }
        };
    }
}

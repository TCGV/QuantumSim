using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class CXGate : BinaryOperation
    {
        public override void Apply(Qubit q1, Qubit q2)
        {
            Quvec v = null;
            if (q1.V == q2.V)
                v = q1.V;
            else
                v = Combine(q1, q2);
            v.MultiplyBy(cx_matrix);
        }

        private Quvec Combine(Qubit q1, Qubit q2)
        {
            var v = Quvec.Combine(q1.V, q2.V);
            q1.SetVec(v, 1);
            q2.SetVec(v, 0);
            return v;
        }

        private readonly Complex[,] cx_matrix = new Complex[,]
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, 1 },
            { 0, 0, 1, 0 }
        };
    }
}

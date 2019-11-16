using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public abstract class BinaryOperation
    {
        public abstract void Apply(Qubit q1, Qubit q2);
    }
}

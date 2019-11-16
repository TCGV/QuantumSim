using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public abstract class UnaryOperation
    {
        public abstract void Apply(Qubit q);
    }
}

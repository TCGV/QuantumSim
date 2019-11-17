using System.Numerics;

namespace Tcgv.QuantumSim.Operations
{
    public class CZGate : BinaryOperation
    {
        protected override Complex[,] GetMatrix()
        {
            return cz_matrix;
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

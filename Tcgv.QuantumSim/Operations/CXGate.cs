using System.Numerics;

namespace Tcgv.QuantumSim.Operations
{
    public class CXGate : BinaryOperation
    {
        protected override Complex[,] GetMatrix()
        {
            return cx_matrix;
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

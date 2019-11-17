using System;
using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class HGate : UnaryOperation
    {
        protected override Complex[,] GetMatrix()
        {
            return h_matrix;
        }

        private readonly Complex[,] h_matrix = new Complex[,]
        {
            { 1 / Math.Sqrt(2), 1 / Math.Sqrt(2) },
            { 1 / Math.Sqrt(2), -1 / Math.Sqrt(2) }
        };
    }
}

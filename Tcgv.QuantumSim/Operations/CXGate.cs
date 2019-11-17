﻿using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    public class CXGate : BinaryOperation
    {
        public override void Apply(Qubit q1, Qubit q2)
        {
            Qubit.Combine(q1, q2);
            q1.V.MultiplyBy(cx_matrix, q1.Id, q2.Id);
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

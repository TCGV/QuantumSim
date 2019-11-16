using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    [TestClass()]
    public class HGateTest
    {
        [TestMethod()]
        public void ApplyTest()
        {
            var diff = 0.0d;
            var iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var q = new Qubit(false);
                new HGate().Apply(q);
                diff += q.Measure() ? 1 : -1;
            }

            Assert.IsTrue(Math.Abs(diff) / iterations < 0.025);
        }
    }
}
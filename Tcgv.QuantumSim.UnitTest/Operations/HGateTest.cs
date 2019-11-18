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

        [TestMethod()]
        public void Apply_TwoQubitSystem_Test()
        {
            var diff = 0.0d;
            var iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var q1 = new Qubit(false);
                var q2 = new Qubit(true);

                Qubit.Combine(q1, q2);

                new HGate().Apply(q1);
                diff += q1.Measure() ? 1 : -1;
            }

            Assert.IsTrue(Math.Abs(diff) / iterations < 0.025);
        }

        [TestMethod()]
        public void Apply_ThreeQubitSystem_Test()
        {
            var diff = 0.0d;
            var iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var q1 = new Qubit(false);
                var q2 = new Qubit(true);
                var q3 = new Qubit(true);

                Qubit.Combine(q1, q2);
                Qubit.Combine(q2, q3);

                new HGate().Apply(q2);
                diff += q2.Measure() ? 1 : -1;
            }

            Assert.IsTrue(Math.Abs(diff) / iterations < 0.025);
        }
    }
}
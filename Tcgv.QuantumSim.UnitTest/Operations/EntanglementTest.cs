using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    [TestClass()]
    public class EntanglementTest
    {
        [TestMethod()]
        public void DirectEntanglementTest()
        {
            var diff = 0.0d;
            var iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var q1 = new Qubit(false);
                var q2 = new Qubit(false);

                new HGate().Apply(q1);
                new CXGate().Apply(q1, q2);

                Assert.IsNull(q1.Peek());
                Assert.IsNull(q2.Peek());

                diff += q1.Measure() ? 1 : -1;
                if (q1.Measure() != q2.Measure())
                    Assert.Fail();
            }

            Assert.IsTrue(Math.Abs(diff) / iterations < 0.025);
        }

        [TestMethod()]
        public void InverseEntanglementTest()
        {
            var diff = 0.0d;
            var iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var q1 = new Qubit(false);
                var q2 = new Qubit(false);

                new HGate().Apply(q1);
                new CXGate().Apply(q1, q2);
                new XGate().Apply(q1);

                Assert.IsNull(q1.Peek());
                Assert.IsNull(q2.Peek());

                diff += q1.Measure() ? 1 : -1;
                if (q1.Measure() == q2.Measure())
                    Assert.Fail();
            }

            Assert.IsTrue(Math.Abs(diff) / iterations < 0.025);
        }
    }
}
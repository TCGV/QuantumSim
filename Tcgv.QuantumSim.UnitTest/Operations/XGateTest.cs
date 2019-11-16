using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    [TestClass()]
    public class XGateTest
    {
        [TestMethod()]
        public void NegateFalseTest()
        {
            var q = new Qubit(false);
            new XGate().Apply(q);
            Assert.IsTrue(q.Measure());
        }

        [TestMethod()]
        public void NegateTrueTest()
        {
            var q = new Qubit(true);
            new XGate().Apply(q);
            Assert.IsFalse(q.Measure());
        }
    }
}
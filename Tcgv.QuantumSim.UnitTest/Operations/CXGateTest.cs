using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    [TestClass()]
    public class CXGateTest
    {
        [TestMethod()]
        public void ControlFalse_InputFalse_Test()
        {
            var c = new Qubit(false);
            var q = new Qubit(false);
            new CXGate().Apply(c, q);
            Assert.IsFalse(c.Measure());
            Assert.IsFalse(q.Measure());
        }

        [TestMethod()]
        public void ControlFalse_InputTrue_Test()
        {
            var c = new Qubit(false);
            var q = new Qubit(true);
            new CXGate().Apply(c, q);
            Assert.IsFalse(c.Measure());
            Assert.IsTrue(q.Measure());
        }

        [TestMethod()]
        public void ControlTrue_InputFalse_Test()
        {
            var c = new Qubit(true);
            var q = new Qubit(false);
            new CXGate().Apply(c, q);
            Assert.IsTrue(c.Measure());
            Assert.IsTrue(q.Measure());
        }

        [TestMethod()]
        public void ControlTrue_InputTrue_Test()
        {
            var c = new Qubit(true);
            var q = new Qubit(true);
            new CXGate().Apply(c, q);
            Assert.IsTrue(c.Measure());
            Assert.IsFalse(q.Measure());
        }
    }
}
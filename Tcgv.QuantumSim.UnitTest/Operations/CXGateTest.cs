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

        [TestMethod()]
        public void ThreeQubitSystem_ControlFalse_InputFalse_Test()
        {
            var c = new Qubit(false);
            var q = new Qubit(false);
            var x = new Qubit(true);

            Qubit.Combine(q, x);
            Qubit.Combine(c, q);

            new CXGate().Apply(c, q);
            Assert.IsFalse(c.Measure());
            Assert.IsFalse(q.Measure());
            Assert.IsTrue(x.Measure());
        }

        [TestMethod()]
        public void ThreeQubitSystem_ControlFalse_InputTrue_Test()
        {
            var c = new Qubit(false);
            var q = new Qubit(true);
            var x = new Qubit(true);

            Qubit.Combine(q, x);
            Qubit.Combine(c, q);

            new CXGate().Apply(c, q);
            Assert.IsFalse(c.Measure());
            Assert.IsTrue(q.Measure());
            Assert.IsTrue(x.Measure());
        }

        [TestMethod()]
        public void ThreeQubitSystem_ControlTrue_InputFalse_Test()
        {
            var c = new Qubit(true);
            var q = new Qubit(false);
            var x = new Qubit(true);

            Qubit.Combine(c, q);
            Qubit.Combine(q, x);

            new CXGate().Apply(c, q);
            Assert.IsTrue(c.Measure());
            Assert.IsTrue(q.Measure());
            Assert.IsTrue(x.Measure());
        }

        [TestMethod()]
        public void ThreeQubitSystem_ControlTrue_InputTrue_Test()
        {
            var c = new Qubit(true);
            var q = new Qubit(true);
            var x = new Qubit(false);

            Qubit.Combine(c, q);
            Qubit.Combine(q, x);

            new CXGate().Apply(c, q);
            Assert.IsTrue(c.Measure());
            Assert.IsFalse(q.Measure());
            Assert.IsFalse(x.Measure());
        }
    }
}
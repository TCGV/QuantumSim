using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Operations
{
    [TestClass()]
    public class TeleportationTest
    {
        [TestMethod()]
        public void Teleportation_FalseQubit_Test()
        {
            var q1 = new Qubit(false);
            var q2 = new Qubit(false);
            var q3 = new Qubit(false);

            new HGate().Apply(q2);
            new CXGate().Apply(q2, q3);
            new CXGate().Apply(q1, q2);
            new HGate().Apply(q1);

            var b1 = q1.Measure();
            var b2 = q2.Measure();

            if (b2)
                new XGate().Apply(q3);
            if (b1)
                new ZGate().Apply(q3);

            if (b1 != q3.Measure())
                Assert.Fail();
        }
    }
}
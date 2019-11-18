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
            var sender = new Qubit(false);
            var recv = new Qubit(false);

            var b = Teleport(sender, recv, false);

            Assert.IsFalse(b);
        }

        [TestMethod()]
        public void Teleportation_TrueQubit_Test()
        {
            var sender = new Qubit(false);
            var recv = new Qubit(false);

            var b = Teleport(sender, recv, true);

            Assert.IsTrue(b);
        }

        private static bool Teleport(Qubit sender, Qubit recv, bool message)
        {
            var msg = new Qubit(message);

            new HGate().Apply(sender);
            new CXGate().Apply(sender, recv);

            new CXGate().Apply(msg, sender);
            new HGate().Apply(msg);

            var bMsg = msg.Measure();
            var bSender = sender.Measure();

            if (bSender)
                new XGate().Apply(recv);
            if (bMsg)
                new ZGate().Apply(recv);

            var bRecv = recv.Measure();
            if (message != bRecv)
                Assert.Fail();

            return bRecv;
        }
    }
}
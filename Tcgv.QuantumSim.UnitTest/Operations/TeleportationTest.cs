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
            var msg = new Qubit(false);
            var recv = new Qubit(false);

            var b = Teleport(sender, msg, recv);
            Assert.IsFalse(b);
        }

        [TestMethod()]
        public void Teleportation_TrueQubit_Test()
        {
            var sender = new Qubit(false);
            var msg = new Qubit(true);
            var recv = new Qubit(false);

            var b = Teleport(sender, msg, recv);
            Assert.IsTrue(b);
        }

        private static bool Teleport(Qubit sender, Qubit msg, Qubit recv)
        {
            new HGate().Apply(sender);
            new CXGate().Apply(sender, recv);

            new CXGate().Apply(msg, sender);
            new HGate().Apply(msg);

            var bMsg = msg.Measure();
            var bSender = sender.Measure();

            if (bMsg)
                new XGate().Apply(recv);
            if (bSender)
                new ZGate().Apply(recv);

            var bRecv = recv.Measure();
            if (bMsg != bRecv)
                Assert.Fail();

            return bRecv;
        }
    }
}
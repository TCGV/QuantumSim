using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Tcgv.QuantumSim.Operations;

namespace Tcgv.QuantumSim.Algorithms
{
    [TestClass()]
    public class DeutschAlgorithmTests
    {
        [TestMethod()]
        public void BalancedGateTest()
        {
            var algo = new DeutschAlgorithm();

            Assert.IsTrue(algo.IsBalanced(new BalancedGate()));
        }

        [TestMethod()]
        public void ConstantGateTest()
        {
            var algo = new DeutschAlgorithm();

            Assert.IsFalse(algo.IsBalanced(new ConstantGate()));
        }

        public class BalancedGate : BinaryOperation
        {
            protected override Complex[,] GetMatrix()
            {
                return new Complex[,]
                {
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 1, 0, 0, 0 },
                    { 0, 0, 0, 1 }
                };
            }
        }

        public class ConstantGate : BinaryOperation
        {
            protected override Complex[,] GetMatrix()
            {
                return new Complex[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
            }
        }
    }
}
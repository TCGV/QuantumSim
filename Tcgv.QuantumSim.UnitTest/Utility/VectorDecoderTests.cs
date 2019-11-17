using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Utility
{
    [TestClass()]
    public class VectorDecoderTests
    {
        [TestMethod()]
        public void SinglePoint_Test()
        {
            var decoder = new VectorDecoder();

            var p = new CPoint(
                new Complex(1 / sqrt2, 0),
                new Complex(-1 / sqrt2, 0)
            );

            var r = decoder.Solve(new[] { p.X, p.Y });

            Assert.AreEqual(p, r[0]);
        }

        [TestMethod()]
        public void TwoPoints_Solvable_Test()
        {
            var decoder = new VectorDecoder();

            var p1 = new CPoint(
                new Complex(1 / sqrt2, 0),
                new Complex(-1 / sqrt2, 0)
            );

            var p2 = new CPoint(
                new Complex(3.0d / 4, 0),
                new Complex(sqrt7 / 4, 0)
            );

            var v = AlgebraUtility.TensorProduct(new[] { p1, p2 });
            var r = decoder.Solve(v);

            Assert.AreEqual(p1, r[0]);
            Assert.AreEqual(p2, r[1]);
        }

        [TestMethod()]
        public void TwoPoints_NotSolvable_Test()
        {
            var decoder = new VectorDecoder();

            var v = new[]
            {
                new Complex(1 / sqrt2, 0),
                Complex.Zero,
                Complex.Zero,
                new Complex(sqrt7 / 4, 0)
            };

            var r = decoder.Solve(v);

            Assert.IsNull(r);
        }

        private readonly double sqrt7 = Math.Sqrt(7);
        private readonly double sqrt2 = Math.Sqrt(2);
    }
}
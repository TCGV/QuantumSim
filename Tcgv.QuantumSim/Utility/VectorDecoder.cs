using System;
using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Utility
{
    public class VectorDecoder
    {
        public CPoint[] Solve(Complex[] vector)
        {
            if (vector.Length == 2)
                return SolveSinglePoint(vector);
            if (vector.Length == 4)
                return SolveTwoPoints(vector);
            else
                throw new NotImplementedException();
        }

        private CPoint[] SolveSinglePoint(Complex[] vector)
        {
            var v = new[] { new CPoint(vector[0], vector[1]) };
            return Normalize(v);
        }

        private CPoint[] SolveTwoPoints(Complex[] vector)
        {
            var p1 = new CPoint(
                            1,
                            vector[2] / vector[0]
                        );

            var p2 = new CPoint(
                vector[0],
                vector[1]
            );

            if (vector[0] * vector[3] != vector[1] * vector[2])
                return null;

            return Normalize(new[] { p1, p2 });
        }

        private CPoint[] Normalize(CPoint[] points)
        {
            foreach (var p in points)
            {
                var m = p.Magnetude();
                if (!IsOne(m))
                    p.DivideBy(m);
            }
            return points;
        }

        private bool IsOne(double v)
        {
            return Math.Abs(1.0d - v) < 1e-15;
        }
    }
}

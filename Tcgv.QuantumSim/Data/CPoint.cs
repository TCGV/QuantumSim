using System;
using System.Numerics;

namespace Tcgv.QuantumSim.Data
{
    public class CPoint
    {
        public CPoint(bool b)
        {
            X = b ? 0 : 1;
            Y = b ? 1 : 0;
        }

        public CPoint(Complex x, Complex y)
        {
            X = x;
            Y = y;
        }

        public Complex X { get; private set; }
        public Complex Y { get; private set; }

        public double Magnetude()
        {
            return Math.Sqrt(
                X.Magnitude * X.Magnitude + Y.Magnitude * Y.Magnitude
            );
        }

        public void DivideBy(double v)
        {
            X /= v;
            Y /= v;
        }

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var p = obj as CPoint;
            return p != null && p.X == X && p.Y == Y;
        }
    }
}

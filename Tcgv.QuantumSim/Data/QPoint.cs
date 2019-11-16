using System.Numerics;

namespace Tcgv.QuantumSim.Data
{
    public class QPoint
    {
        public QPoint(bool b)
        {
            X = b ? 0 : 1;
            Y = b ? 1 : 0;
        }

        public QPoint(Complex x, Complex y)
        {
            X = x;
            Y = y;
        }

        public Complex X { get; private set; }
        public Complex Y { get; private set; }
    }
}

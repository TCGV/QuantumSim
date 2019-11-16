using System;
using System.Numerics;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Data
{
    public class Quvec
    {
        public Quvec(params QPoint[] points)
        {
            v = AlgebraUtility.TensorProduct(points);
        }

        public static Quvec Combine(Quvec v1, Quvec v2)
        {
            var v = new Quvec();
            v.v = AlgebraUtility.TensorProduct(v1.v, v2.v);
            return v;
        }

        public int GetLength()
        {
            return v.Length;
        }

        public void MultiplyBy(Complex[,] matrix)
        {
            v = AlgebraUtility.Multiply(matrix, v);
        }

        public bool Measure(int pos)
        {
            if (!measure.HasValue)
            {
                var i = 0;
                var aux = 0.0d;
                var x = RandomUtility.NextDouble();

                for (; i < v.Length; i++)
                {
                    aux += v[i].Magnitude * v[i].Magnitude;
                    if (aux > x)
                        break;
                    v[i] = 0;
                }
                measure = i;
            }

            return (measure & (1 << pos)) != 0;
        }

        private Complex[] v;
        private int? measure;
    }
}

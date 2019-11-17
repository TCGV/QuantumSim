using System;
using System.Collections.Generic;
using System.Numerics;
using Tcgv.QuantumSim.Utility;

namespace Tcgv.QuantumSim.Data
{
    public class Quvec
    {
        Quvec()
        {
            posMap = new Dictionary<int, int>();
        }

        public Quvec(CPoint p, int key) : this()
        {
            posMap.Add(key, 0);
            v = new[] { p.X, p.Y };
        }

        public static Quvec Combine(Quvec v1, Quvec v2)
        {
            var v = new Quvec();
            v.v = AlgebraUtility.TensorProduct(v1.v, v2.v);
            v.posMap = v2.posMap;
            foreach (var pair in v1.posMap)
                v.posMap.Add(pair.Key, pair.Value + v1.posMap.Count);
            return v;
        }

        public void MultiplyBy(Complex[,] matrix, int key1, int key2)
        {
            var l = v.Length;

            if (l > matrix.GetLength(0))
            {
                var pos1 = posMap[key1];
                var pos2 = posMap[key2];

                throw new NotImplementedException();
            }

            v = AlgebraUtility.Multiply(matrix, v);
        }

        public void MultiplyBy(Complex[,] matrix, int key)
        {
            var l = v.Length;

            if (l > matrix.GetLength(0))
            {
                var pos = posMap[key];
                matrix = Expand(matrix, l, pos);
            }

            v = AlgebraUtility.Multiply(matrix, v);
        }

        public CPoint Peek(int key)
        {
            var decomposer = new VectorDecoder();
            var r = decomposer.Solve(v);
            if (r != null)
                return r[r.Length - posMap[key] - 1]; // big-endian
            return null;
        }

        public bool Measure(int key)
        {
            int pos = posMap[key];

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

        private Complex[,] Expand(Complex[,] matrix, int len, int pos)
        {
            if (pos > 0)
                matrix = AlgebraUtility.TensorProduct(
                        AlgebraUtility.Identity(pos * 2), matrix
                    );
            if (pos + 1 < len / 2)
                matrix = AlgebraUtility.TensorProduct(
                        matrix, AlgebraUtility.Identity((len / 2 - pos - 1))
                    );
            return matrix;
        }

        private Dictionary<int, int> posMap;
        private Complex[] v;
        private int? measure;
    }
}

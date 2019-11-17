using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Tcgv.QuantumSim.Operations;
using Tcgv.QuantumSim.Utility;
using System;

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
            var offset = v2.posMap.Count;
            foreach (var pair in v1.posMap)
                v.posMap.Add(pair.Key, pair.Value + offset);
            return v;
        }

        public void MultiplyBy(UnaryOperation gate, int key)
        {
            var bitLen = AlgebraUtility.Log2(v.Length);
            var bitPosition = posMap[key];
            v = AlgebraUtility.Multiply(
                gate.GetMatrix(bitLen, bitPosition), v
            );
        }

        public void MultiplyBy(BinaryOperation gate, int key1, int key2)
        {
            var bitLen = AlgebraUtility.Log2(v.Length);
            var bit1Pos = posMap[key1];
            var bit2Pos = posMap[key2];
            v = AlgebraUtility.Multiply(
                gate.GetMatrix(bitLen, bit1Pos, bit2Pos), v
            );
        }

        public CPoint Peek(int key)
        {
            var decoder = new VectorDecoder();
            var r = decoder.Solve(v);
            if (r != null)
                return r[r.Length - posMap[key] - 1]; // big-endian
            return null;
        }

        public bool Measure(int key)
        {
            int pos = posMap[key];

            int val = Measure();
            bool m = BinaryUtility.HasBit(val, pos);
            Collapse(pos, m);

            return m;
        }

        private int Measure()
        {
            var i = 0;
            var aux = 0.0d;
            var x = RandomUtility.NextDouble();

            for (; i < v.Length; i++)
            {
                aux += v[i].Magnitude * v[i].Magnitude;
                if (aux > x)
                    break;
            }

            return i;
        }

        private void Collapse(int pos, bool b)
        {
            for (int i = 0; i < v.Length; i++)
                if (BinaryUtility.HasBit(i, pos) != b)
                    v[i] = Complex.Zero;

            var sum = Math.Sqrt(
                v.Sum(x => x.Magnitude * x.Magnitude)
            );
            for (int i = 0; i < v.Length; i++)
                v[i] /= sum;
        }

        private Dictionary<int, int> posMap;
        private Complex[] v;
    }
}

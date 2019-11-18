using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Tcgv.QuantumSim.Data;

namespace Tcgv.QuantumSim.Utility
{
    public static class AlgebraUtility
    {
        public static int Log2(int length)
        {
            return (int)Math.Round(Math.Log(length, 2));
        }

        public static Complex[] IntToVector(int bitLen, int value)
        {
            var v = new Complex[bitLen];
            v[value] = Complex.One;
            return v;
        }

        public static IEnumerable<int> VectorToInt(Complex[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
                if (vector[i] != Complex.Zero)
                    yield return i;
        }

        public static Dictionary<int, Dictionary<int, Complex>> LookupTable(Complex[,] matrix)
        {
            var bitLen = matrix.GetLength(0);
            var table = new Dictionary<int, Dictionary<int, Complex>>();
            for (int i = 0; i < bitLen; i++)
            {
                var vector = IntToVector(bitLen, i);
                var result = Multiply(matrix, vector);

                table.Add(i, new Dictionary<int, Complex>());
                foreach (var j in VectorToInt(result))
                {
                    table[i].Add(j, result[j]);
                }
            }
            return table;
        }

        public static Complex[] Multiply(Complex[,] matrix, Complex[] vector)
        {
            if (matrix.GetLength(0) != vector.Length)
                throw new InvalidOperationException();

            var r = new Complex[vector.Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                r[i] = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    r[i] += vector[j] * matrix[i, j];
            }

            return r;
        }

        public static Complex[] TensorProduct(Complex[] v1, Complex[] v2)
        {
            var w = v1.Length * v2.Length;
            var v = new Complex[w];

            for (int i = 0; i < v1.Length; i++)
            {
                for (int j = 0; j < v2.Length; j++)
                {
                    v[i * v2.Length + j] = v1[i] * v2[j];
                }
            }

            return v;
        }

        public static Complex[] TensorProduct(CPoint[] points)
        {
            return TensorProduct(points, 0).ToArray();
        }

        private static IEnumerable<Complex> TensorProduct(CPoint[] points, int offset)
        {
            if (offset < points.Length)
            {
                foreach (var v in TensorProduct(points, offset + 1))
                    yield return points[offset].X * v;
                foreach (var v in TensorProduct(points, offset + 1))
                    yield return points[offset].Y * v;
            }
            else
            {
                yield return 1;
            }
        }
    }
}

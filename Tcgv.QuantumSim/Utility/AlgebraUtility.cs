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

        public static Complex[,] Identity(int l)
        {
            var m = new Complex[l, l];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    m[i, j] = i == j ? 1 : 0;
                }
            }
            return m;
        }

        public static Complex[] IntToVector(int bitLen, int value)
        {
            var v = new Complex[bitLen];
            v[value] = Complex.One;
            return v;
        }

        public static int VectorToInt(Complex[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
                if (vector[i] == Complex.One)
                    return i;
            throw new InvalidOperationException();
        }

        public static Complex[,] Sum(Complex[,] v1, Complex[,] v2)
        {
            if (v1.GetLength(0) != v2.GetLength(0) ||
                v1.GetLength(1) != v2.GetLength(1))
                throw new InvalidOperationException();

            var r = new Complex[v1.GetLength(0), v1.GetLength(1)];

            for (int i = 0; i < v1.GetLength(0); i++)
            {
                for (int j = 0; j < v1.GetLength(1); j++)
                {
                    r[i, j] = v1[i, j] + v2[i, j];
                }
            }

            return r;
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

        public static Complex[,] TensorProduct(Complex[,] v1, Complex[,] v2)
        {
            var w = v1.GetLength(0) * v2.GetLength(0);
            var h = v1.GetLength(1) * v2.GetLength(1);
            var v = new Complex[w, h];

            for (int i = 0; i < v1.GetLength(0); i++)
            {
                for (int j = 0; j < v1.GetLength(1); j++)
                {
                    for (int k = 0; k < v2.GetLength(0); k++)
                    {
                        for (int l = 0; l < v2.GetLength(1); l++)
                        {
                            v[i * v2.GetLength(0) + k, j * v2.GetLength(1) + l] =
                                v1[i, j] * v2[k, l];
                        }
                    }
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

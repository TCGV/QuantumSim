using System.Collections.Generic;

namespace Tcgv.QuantumSim.Data
{
    public class Qubit
    {
        public Qubit(bool b)
        {
            Id = (++counter);
            SetV(new Quvec(new CPoint(b), Id));
        }

        public int Id { get; private set; }
        public Quvec V { get; private set; }

        public static void Combine(Qubit q1, Qubit q2)
        {
            var v1 = q1.V;
            var v2 = q2.V;
            if (v1 != v2)
            {
                var v = Quvec.Combine(v1, v2);
                UpdateCache(v1, v);
                UpdateCache(v2, v);
            }
        }

        public CPoint Peek()
        {
            return V.Peek(Id);
        }

        public bool Measure()
        {
            return V.Measure(Id);
        }

        private void SetV(Quvec v)
        {
            V = v;
            AddToCache();
        }

        private void AddToCache()
        {
            if (!cache.ContainsKey(V))
                cache.Add(V, new List<Qubit>());
            cache[V].Add(this);
        }

        private static void UpdateCache(Quvec old, Quvec @new)
        {
            foreach (var bit in cache[old])
                bit.SetV(@new);
            cache.Remove(old);
        }

        private static Dictionary<Quvec, List<Qubit>> cache =
            new Dictionary<Quvec, List<Qubit>>();
        private static int counter = 0;
    }
}

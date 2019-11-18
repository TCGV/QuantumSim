using System.Collections.Generic;

namespace Tcgv.QuantumSim.Data
{
    public class Qubit
    {
        public Qubit(bool b)
        {
            Id = (++counter);
            SetV(new Qstate(new CPoint(b), Id));
        }

        public int Id { get; private set; }
        public Qstate S { get; private set; }

        public static void Combine(Qubit q1, Qubit q2)
        {
            var v1 = q1.S;
            var v2 = q2.S;
            if (v1 != v2)
            {
                var v = Qstate.Combine(v1, v2);
                UpdateCache(v1, v);
                UpdateCache(v2, v);
            }
        }

        public CPoint Peek()
        {
            return S.Peek(Id);
        }

        public bool Measure()
        {
            return S.Measure(Id);
        }

        private void SetV(Qstate v)
        {
            S = v;
            AddToCache();
        }

        private void AddToCache()
        {
            if (!cache.ContainsKey(S))
                cache.Add(S, new List<Qubit>());
            cache[S].Add(this);
        }

        private static void UpdateCache(Qstate old, Qstate @new)
        {
            foreach (var bit in cache[old])
                bit.SetV(@new);
            cache.Remove(old);
        }

        private static Dictionary<Qstate, List<Qubit>> cache =
            new Dictionary<Qstate, List<Qubit>>();
        private static int counter = 0;
    }
}

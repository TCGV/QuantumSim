using System.Collections.Generic;

namespace Tcgv.QuantumSim.Data
{
    public class Qubit
    {
        public Qubit(bool b)
        {
            Id = (++counter);
            SetState(new Qstate(new CPoint(b), Id));
        }

        public int Id { get; private set; }
        public Qstate S { get; private set; }

        public static void Combine(Qubit q1, Qubit q2)
        {
            var s1 = q1.S;
            var s2 = q2.S;
            if (s1 != s2)
            {
                var s = Qstate.Combine(s1, s2);
                UpdateCache(s1, s);
                UpdateCache(s2, s);
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

        private void SetState(Qstate s)
        {
            S = s;
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
                bit.SetState(@new);
            cache.Remove(old);
        }

        private static Dictionary<Qstate, List<Qubit>> cache =
            new Dictionary<Qstate, List<Qubit>>();
        private static int counter = 0;
    }
}

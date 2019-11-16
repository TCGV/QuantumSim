using System;

namespace Tcgv.QuantumSim.Utility
{
    public static class RandomUtility
    {
        public static double NextDouble()
        {
            return rd.NextDouble();
        }

        private static Random rd = new Random(
            Guid.NewGuid().GetHashCode()
        );
    }
}

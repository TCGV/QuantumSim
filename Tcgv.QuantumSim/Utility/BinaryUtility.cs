namespace Tcgv.QuantumSim.Utility
{
    public static class BinaryUtility
    {
        public static bool HasBit(int x, int pos)
        {
            return (x & (1 << pos)) != 0;
        }

        public static int SetBit(int x, int pos, bool v)
        {
            return (x & (~(1 << pos))) | ((v ? 1 : 0) << pos);
        }
    }
}

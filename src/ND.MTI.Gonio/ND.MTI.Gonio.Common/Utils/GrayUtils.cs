namespace ND.MTI.Gonio.Common.Utils
{
    public static class GrayUtils
    {
        public static int GrayToInteger(string gray)
        {
            int.TryParse(gray, out var n);
            var inv = 0;

            for (; n != 0; n >>= 1)
                inv ^= n;

            return inv;
        }
    }
}

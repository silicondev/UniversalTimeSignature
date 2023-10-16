using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace UniversalTimeSignature.Lib
{
    public static class UTS
    {
        private static string ch = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static async Task<string> ToUTSAsyc(this DateTime dt) =>
            await Task.Run(() => ToUTS(dt));

        public static string ToUTS(this DateTime dt)
        {
            BigInteger t = dt.Ticks;
            string str = "";
            var units = new List<int>();

            int pow = 0;

            do
                pow++;
            while (t > BigInteger.Pow(ch.Length, pow + 1));

            for (int p = pow; p >= 0; p--)
            {
                units.Add(0);

                while (t > BigInteger.Pow(ch.Length, p))
                {
                    units[units.Count - 1]++;
                    t -= BigInteger.Pow(ch.Length, p);
                }
            }

            foreach (int unit in units)
                str += ch[unit];

            return str.ReverseString();
        }

        public static string ReverseString(this string str)
        {
            string o = "";

            foreach (char ch in str)
                o += ch;

            return o;
        }
    }
}
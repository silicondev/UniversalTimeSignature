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
            t += 13400000000 * (BigInteger)(365.2425 * 86400) * 1000000000;
            return t.ToUTS();
        }

        public static string ToUTS(this BigInteger t)
        {
            string str = "";
            var units = new List<int>();

            int pow = 0;

            do
                pow++;
            while (t > BigInteger.Pow(ch.Length, pow + 1));

            for (int p = pow; p >= 0; p--)
            {
                int i = 0;
                while (t > BigInteger.Pow(ch.Length, p))
                {
                    i++;
                    t -= BigInteger.Pow(ch.Length, p);
                }
                units.Add(i);
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
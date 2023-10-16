using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

namespace UniversalTimeSignature.Lib
{
    public static class UTS
    {
        private static string ch = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 13.4 Billion years in Ticks
        /// </summary>
        public static BigInteger BigBang = 13400000000 * (BigInteger)(365.2425 * 86400) * 1000000000;

        public static async Task<string> ToUTSAsyc(this DateTime dt) =>
            await Task.Run(() => ToUTS(dt));

        public static async Task<string> ToUTSAsyc(this BigInteger bi) =>
            await Task.Run(() => ToUTS(bi));

        public static string ToUTS(this DateTime dt)
        {
            BigInteger t = dt.Ticks;
            t += BigBang;
            return t.ToUTS();
        }

        public static string ToUTS(this BigInteger t)
        {
            string str = "";
            int pow = 0;

            while (t > BigInteger.Pow(ch.Length, pow + 1))
                pow++;

            do
            {
                int i = 0;
                BigInteger unit = BigInteger.Pow(ch.Length, pow);
                while (t >= unit)
                {
                    i++;
                    t -= unit;
                }
                str += ch[i];
                pow--;
            }
            while (pow >= 0);

            return str;
        }
    }
}
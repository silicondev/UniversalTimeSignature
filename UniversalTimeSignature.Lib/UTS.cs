using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversalTimeSignature.Lib
{
    public static class UTS
    {
        private static string ch = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string ToUTS(this DateTime dt)
        {
            long t = dt.Ticks;
            string str = "";
            //int index = 0;
            var units = new List<int>() { 0 };

            int pow = 1;

            while (t > Math.Pow(ch.Length, pow))
                pow++;

            pow--;

            for (int p = 0; p < pow - 1; p++)
            {
                // THIS WONT WORK YET
                int i = p;
                for (; ; )
                {
                    if (units.Count == i)
                    {
                        units.Add(1);
                        break;
                    }
                    else
                    {
                        units[i]++;
                        if (units[i] < 62)
                            break;
                        else
                            units[i] = 0;
                    }
                    i++;
                }
            }

            while (t > 0)
            {
                //if (str.Length < index + 1)
                //{
                //    str += ch[1];
                //    index = 0;
                //}
                //else
                //{
                //    int chi = ch.IndexOf(str[index]) + 1;
                //    if (chi >= ch.Length)
                //    {
                //        str = str.Swap(index, ch[0]);
                //        index++;
                //        t++;
                //    }
                //    else
                //    {
                //        str = str.Swap(index, ch[chi]);
                //        index = 0;
                //    }
                //}

                int i = 0;
                for ( ; ; )
                {
                    if (units.Count == i)
                    {
                        units.Add(1);
                        break;
                    }
                    else
                    {
                        units[i]++;
                        if (units[i] < 62)
                            break;
                        else
                            units[i] = 0;
                    }
                    i++;
                }

                t--;
            }

            foreach (int unit in units)
                str += ch[unit];

            return str.Reverse().ToString();
        }

        private static List<int> Advance(List<int> l, int max, int index = 0)
        {
            var list = new List<int>(l);

            if (list.Count > index)
            {
                list[index]++;
                if (list[index] >= max)
                {
                    list[index] = 0;
                    return Advance(list, max, index + 1);
                }
            }
            else
                list.Add(1);

            return list;
        }

        //public static string Swap(this string str, int index, char ch) =>
        //    str.Remove(index, 1).Insert(index, ch.ToString());

        public static string Swap(this string str, int index, char ch)
        {
            string s = str;
            s = s.Remove(index, 1);
            s = s.Insert(index, ch.ToString());
            return s;
        }
    }
}
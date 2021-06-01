using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class Interop01Wrapper
    {
        [DllImport("CPPTEST.dll", CharSet = CharSet.Ansi)]
        private static extern void ReverseAnsiString(string rawString, StringBuilder reversedString);


        public static void ReverseAnsiStringTest()
        {
            ffff("abcedfg");
            ffff("我是中国人");
            ffff("abcdefg我是中国人");
        }

        private static void ffff(string rawString)
        {
            StringBuilder sbReversed = new StringBuilder(rawString.Length);

            ReverseAnsiString(rawString, sbReversed);
            Console.WriteLine($"rawString:{rawString}{Environment.NewLine} sbReversed:{sbReversed}");
        }


        #region 宽字符窄字符调用性能对比


        [DllImport("CPPTEST.dll", CharSet = CharSet.Ansi)]
        public static extern bool IsAsciiNonbittable(char asciiChar);

        [DllImport("CPPTEST.dll", CharSet = CharSet.Unicode)]
        public static extern bool IsWasciiNonbittable(char wasciiChar);


        public static void CompairWideAndAnsiChar()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int count = 6000000;
            for (int i = 0; i < count; i++)
            {
                IsAsciiNonbittable('a');
            }

            sw.Stop();
            Console.WriteLine($"调用{count}次Ansi字符，耗时:{sw.ElapsedMilliseconds}");

            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                IsWasciiNonbittable('a');
            }

            sw.Stop();
            Console.WriteLine($"调用{count}次宽字符，耗时:{sw.ElapsedMilliseconds}");
        }

        #endregion

    }
}

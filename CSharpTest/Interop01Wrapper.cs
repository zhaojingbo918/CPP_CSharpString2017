using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class Interop01Wrapper
    {
        [DllImport("CPPTEST.dll",CharSet = CharSet.Ansi)]
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
    }
}

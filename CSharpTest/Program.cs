using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallUsingStringAsReturnValue();

            CallUsingBSTRAsReturnValue();
            CallUsingWideStringAsReturnValue();
            Console.ReadKey();
        }

        [DllImport("CPPTEST", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string StringReturnAPI01();

        static void CallUsingStringAsReturnValue()
        {
            string strReturn01 = StringReturnAPI01();
            Console.WriteLine("Returned string : " + strReturn01);
        }



        [DllImport("CPPTEST", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string StringReturnAPI02();

        static void CallUsingBSTRAsReturnValue()
        {
            string strReturn = StringReturnAPI02();
            Console.WriteLine("Returned string Using BSTR: " + strReturn);
        }

        [DllImport("CPPTEST.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string StringReturnAPI03();

        static void CallUsingWideStringAsReturnValue()
        {
            string strReturn = StringReturnAPI03();
            Console.WriteLine("Returned string Unicode String: " + strReturn);
        }
    }
}

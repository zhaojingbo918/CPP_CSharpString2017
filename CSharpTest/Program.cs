using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Interop01Wrapper.CompairWideAndAnsiChar();
            Interop01Wrapper.ReverseAnsiStringTest();
            CallUsingStringAsReturnValue();

            CallUsingBSTRAsReturnValue();
            CallUsingWideStringAsReturnValue();

            CallUsingLowLevelStringManagement();

            CallUsingLowLevelStringManagement02();

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

        #region Low-Level Handling Sample 1

        [DllImport("CPPTEST.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr PtrReturnAPI01();

        static void CallUsingLowLevelStringManagement()
        {
            // Receive the pointer to ANSI character array
            // from API.
            IntPtr pStr = PtrReturnAPI01();
            // Construct a string from the pointer.
            string str = Marshal.PtrToStringAnsi(pStr);
            // Free the memory pointed to by the pointer.
            Marshal.FreeHGlobal(pStr);
            pStr = IntPtr.Zero;
            // Display the string.
            Console.WriteLine("Returned string : " + str);
        }
        #endregion


        #region Low-Level Handling Sample 2

        [DllImport("CPPTEST", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr PtrReturnAPI02();


        static void CallUsingLowLevelStringManagement02()
        {
            // Receive the pointer to Unicde character array
            // from API.
            IntPtr pStr = PtrReturnAPI02();
            // Construct a string from the pointer.
            string str = Marshal.PtrToStringUni(pStr);
            // Display the string.
            Console.WriteLine("Returned string : " + str);
        }





        #endregion
    }
}

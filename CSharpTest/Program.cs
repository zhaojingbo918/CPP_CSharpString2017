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


        [DllImport("CPPTEST")]
        public static extern int fnCPPTest2();
    }
}

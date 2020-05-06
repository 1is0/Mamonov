using System;
using System.Runtime.InteropServices;

namespace Example
{
    class Program
    {
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Sh(double x);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Ch(double x);

        static void Main(string[] args)
        {
            Console.WriteLine("Input number:");
            int x = Check();
            Console.WriteLine(@"sh({0}) = {1}
ch({0}) = {2}", x, Sh(x), Ch(x));
            Console.ReadKey();
        }

        public static int Check()
        {
            int a;
            while ((!int.TryParse(Console.ReadLine(), out a)) || (a > 1000) || (a < -1000))
            {
                Console.Write("Incorrect input, repeat, please: ");
            }
            return a;
        }
    }
}

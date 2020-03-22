using System;
using System.Text;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder(Console.ReadLine());
            Random num = new Random();
            for(int i = 0; i < s.Length; i++)
            {
                int index = num.Next(0, s.Length);
                char vo_vrema = s[index];
                s[index] = s[i];
                s[i] = vo_vrema;
            }
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}

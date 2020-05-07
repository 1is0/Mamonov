using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 число:");
            Number a = GetFloatFromUser();

            Console.WriteLine("2 число:");
            Console.WriteLine("N:");
            int n = GetInt32FromUser(-10000000, 10000000);
            Console.WriteLine("M:");
            Number b = new Number(n,GetInt32FromUser(1, 1000000000));
            Console.WriteLine();

            Console.WriteLine($"1 число = {a.DoubleView()} = {a.FactionView()}");
            Console.WriteLine($"2 число = {b.DoubleView()} = {b.FactionView()}");
            Console.WriteLine();

            Console.WriteLine($"1 число ++ = {a++}");
            Console.WriteLine($"1 число -- = {a--}");
            Console.WriteLine();

            Console.WriteLine($"1 число == 2 числу: {a==b}");
            Console.WriteLine($"1 число != 2 числу: {a!=b}");
            Console.WriteLine();

            Console.WriteLine($"1 число > 2 числа: {a > b}");
            Console.WriteLine($"1 число < 2 числа: {a < b}");
            Console.WriteLine($"1 число >= 2 числа: {a >= b}");
            Console.WriteLine($"1 число <= 2 числа: {a <= b}");
            Console.WriteLine();

            Console.WriteLine($"1 число + 2 число: {a + b}");
            Console.WriteLine($"1 число - 2 число: {a - b}");
            Console.WriteLine();

            Console.WriteLine($"1 число * 2 число: {a * b}");
            if (b != 0)
            {
                Console.WriteLine($"1 число / 2 число: {a / b}");
            }
            else
            {
                Console.WriteLine("Division by 0 is impossible");
            }
            Console.WriteLine();

            Console.WriteLine(((Number)53).FactionView());
            Console.WriteLine(((Number)44.32f).FactionView());
            try
            {
                Console.WriteLine(((Number)"32.4").FactionView());
            }
            catch
            {
                Console.WriteLine("NaN");
            }
            Console.WriteLine();

            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());

            Console.ReadKey();
        }

        static int GetInt32FromUser(int from, int to)
        {
            int number;
            Console.WriteLine($"Введите целое число от {from} to {to}:");
            while (!int.TryParse(Console.ReadLine(), out number) || number < from || number > to)    
            {
                Console.WriteLine("Ошибка ввода! Введите еще раз:");
            }
            return number;
        }

        static float GetFloatFromUser()
        {
            float number;
            Console.WriteLine($"Введите вещественное число:");
            while (true)
            {
                try
                {
                    number = Convert.ToSingle(Console.ReadLine());
                    if (number < 10000000)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода! Введите еще раз:");
                }
            }
            return number;
        }
    }
}

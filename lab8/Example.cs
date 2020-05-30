using System;

namespace CSlab3
{
    class Example
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student(University.BSU, 1, 32, "ff");
            }
            catch(ValueException ex)
            {
                Console.WriteLine(ex.Message + ", сhange " + ex.Value);
            }
            
            try
            {
                Economist a = new Economist(University.BSUIR, 1, 17, "John", 7);
                a.Notify += DisplayMessage;
                a.Notify += DisplayGreenMessage;
                a.IncreaseMark(3);
                a.LowerMark(7);
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.Message + ", сhange " + ex.Value);
            }

            try
            {
                Economist b = new Economist(University.BSUIR, 3, 19, "Mary", 9);
                b.Notify += message => Console.WriteLine(message);
                b.Notify += delegate (string message)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ResetColor();       
                };
                b.IncreaseMark(1);
                b.LowerMark(7);
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.Message + ", сhange " + ex.Value);
            }

            try
            {
                Economist c = new Economist(University.BSUIR, 3, 159, "Mary", 9);
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.Message + ", сhange " + ex.Value);
            }

            Console.ReadKey();
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void DisplayGreenMessage(String message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

using System;

namespace CSlab3
{
    sealed class Economist : Student, IWorkable
    {
        public int Mark { get; set; }
        public int SpecialNumber { get; } = 2;
        public override string Major { get; } = "Economist";

        public Economist() { }
        public Economist(University Location, int Year, int Age, string Name, int Mark) : base(Location, Year, Age, Name)
        {
            this.Mark = Mark;
        }
        public Economist(Student student, int Mark) : base(student.GetDeepCopy())
        {
            this.Mark = Mark;
        }

        public new string GetType() { return "Economist"; }

        public override string ToString()
        {
            return base.ToString() + ", mark = " + Mark.ToString();
        }

        public static void SwapMarks(Economist a, Economist b)
        {
            int temp = a.Mark;
            a.Mark = b.Mark;
            b.Mark = temp;
        }

        public void ToWork()
        {
            Console.WriteLine("{0} is counting!!!", Name);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !base.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Economist p = (Economist)obj;
                return (Mark == p.Mark) && base.Equals(obj);
            }
        }
    }
}

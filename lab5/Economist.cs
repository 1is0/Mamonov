using System;

namespace CSlab3
{
    sealed class Economist : Student
    {
        public int Mark { get; set; }

        public Economist() { }
        public Economist(University Location, int Year, int Age, string Name, int Mark) : base(Location, Year, Age, Name)
        {
            this.Mark = Mark;
        }
        public Economist(Student student, int Mark) : base(student.GetDeepCopy())
        {
            this.Mark = Mark;
        }

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

        public string ToCry()
        {
            return "{0} is crying!!!", Name;
        }
    }
}

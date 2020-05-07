using System;

namespace CSlab3
{
    class Economist
    {
        public Student Data { get; set; }
        public int Mark { get; set; }

        public Economist() { }
        public Economist(University Location, int Year, int Age, string Name, int mark)
        {
            this.Mark = mark;
            Data = new Student(Location, Year, Age, Name);
        }
        public Economist(Student student, int mark)
        {
            Data = student.GetDeepCopy();
            this.Mark = mark;
        }

        public override string ToString()
        {
            return Data.ToString() + ", mark = " + Mark.ToString();
        }

        public static void SwapMarks(Economist a, Economist b)
        {
            int temp = a.Mark;
            a.Mark = b.Mark;
            b.Mark = temp;
        }

        public string ToCry()
        {
            return "You are crying!!!";
        }
    }
}

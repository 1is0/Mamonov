using System;

namespace CSlab3
{
    sealed class Engineer : Student, IWorkable
    {
        public int Skill { get; set; }
        public int SpecialNumber { get; } = 3;
        public override string Major { get; } = "Engineer";

        public Engineer() : base() { }
        public Engineer(University Location, int Year, int Age, string Name, int Skill) : base(Location, Year, Age, Name)
        {
            this.Skill = Skill;
        }
        public Engineer(Student student, int Skill) : base(student.GetDeepCopy())
        {
            this.Skill = Skill;
        }

        public override string ToString()
        {
            return base.ToString() + ", skill = " + Skill.ToString();
        }

        public new string GetType() { return "Engineer"; }

        public static void SwapSkills(Engineer a, Engineer b)
        {
            int temp = a.Skill;
            a.Skill = b.Skill;
            b.Skill = temp;
        }

        public void ToWork()
        {
            Console.WriteLine("{0} is repairing university!!!", Name);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !base.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Engineer p = (Engineer)obj;
                return (Skill == p.Skill) && base.Equals(obj);
            }
        }
    }
}

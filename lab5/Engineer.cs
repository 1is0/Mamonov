using System;

namespace CSlab3
{
    sealed class Engineer : Student
    {
        public int Skill { get; set; }

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

        public static void SwapSkills(Engineer a, Engineer b)
        {
            int temp = a.Skill;
            a.Skill = b.Skill;
            b.Skill = temp;
        }

        public string ToRepairUniversity()
        {
            return "{0} is repairing university!!!", Name;
        }
    }
}

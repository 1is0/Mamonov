using System;

namespace CSlab3
{
    class Engineer
    {
        public Student Data { get; set; }
        public int Skill { get; set; }

        public Engineer() { }
        public Engineer(University Location, int Year, int Age, string Name, int Skill)
        {
            this.Skill = Skill;
            Data = new Student(Location, Year, Age, Name);
        }
        public Engineer(Student student, int Skill)
        {
            Data = student.GetDeepCopy();
            this.Skill = Skill;
        }

        public override string ToString()
        {
            return Data.ToString() + ", skill = " + Skill.ToString();
        }

        public static void SwapSkills(Engineer a, Engineer b)
        {
            int temp = a.Skill;
            a.Skill = b.Skill;
            b.Skill = temp;
        }

        public void ToRepairUniversity()
        {
            Console.WriteLine("You are repairing university!!!");
        }
    }
}

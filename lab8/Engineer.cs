namespace CSlab3
{
    sealed class Engineer : Student, IWorkable
    {
        private int skill;
        public int Skill
        {
            get => skill;
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    skill = value;
                }
                else
                {
                    throw new ValueException("Incorrect value of Skill", "skill");
                }
            }
        }

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

        public delegate void AccountSkill(string message);

        private event AccountSkill notify;
        public event AccountSkill Notify
        {
            add
            {
                notify += value;
                System.Console.WriteLine($"{value.Method.Name} was added");
            }
            remove
            {
                notify -= value;
                System.Console.WriteLine($"{value.Method.Name} was removed");
            }
        }

        public void IncreaseSkill(int x)
        {
            if (Skill + x <= 100)
            {
                Skill += x;
                notify?.Invoke($"The skill of {Name} has grown by {x}");
            }
            else
            {
                throw new ValueException("Incorrect value of Skill", "skill");
            }
        }

        public void LowerMark(int x)
        {
            if (Skill - x >= 0)
            {
                Skill -= x;
                notify?.Invoke($"The skill of {Name} has lowered by {x}");
            }
            else
            {
                throw new ValueException("Incorrect value of Skill", "skill");
            }
        }

        public static void SwapSkills(Engineer a, Engineer b)
        {
            int temp = a.Skill;
            a.Skill = b.Skill;
            b.Skill = temp;
        }

        public string ToWork()
        {
            return $"{Name} is repairing university!!!";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
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

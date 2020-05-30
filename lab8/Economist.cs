namespace CSlab3
{
    sealed class Economist : Student, IWorkable
    {
        private int mark;
        public int Mark
        {
            get => mark;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    mark = value;
                }
                else
                {
                    throw new ValueException("Incorrect value of Mark", "mark");
                }
            }
        }
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

        public delegate void AccountMark(string message);

        private void ShowMessage(AccountMark del, string message)
        {
            del?.Invoke(message);
        }

        private event AccountMark notify;
        public event AccountMark Notify
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

        public void IncreaseMark(int x)
        {
            if (Mark + x <= 10)
            {
                Mark += x;
                ShowMessage(notify,$"The mark of {Name} has grown by {x}");
            }
            else
            {
                throw new ValueException("Incorrect value of Mark", "mark");
            }
        }

        public void LowerMark(int x)
        {
            if (Mark - x >= 0)
            {
                Mark -= x;
                ShowMessage(notify,$"The mark of {Name} has lowered by {x}");
            }
            else
            {
                throw new ValueException("Incorrect value of Mark", "mark");
            }
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

        public string ToWork()
        {
            return $"{Name} is counting!!!";
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

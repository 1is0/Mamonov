namespace CSlab3
{
     class Student : Person
    {
        public University Location { get; set; }
        private int year;
        public int Year
        {
            get => year;
            set
            {
                if (value > 0 && value <= 5)
                {
                    year = value;
                }
                else
                {
                    throw new ValueException("Incorrect year input","year");
                }
            }
        }
        public override string Major { get; } = "Student";

        public Student() : base() { }
        public Student(University Location, int Year, int Age, string Name) : base(Age, Name)
        {
            this.Location = Location;
            this.Year = Year;
        }
        public Student(University Location, int Year, Person PersonalData) : base(PersonalData.Age, PersonalData.Name)
        {
            this.Location = Location;
            this.Year = Year;
        }
        public Student(Student student) : base(student.Age, student.Name)
        {
            Location = student.Location;
            Year = student.Year;
        }

        public Student GetShallowCopy() { return (Student)MemberwiseClone(); }
        public Student GetDeepCopy() { return new Student(Location, Year, Age, Name); }

        public override string ToString()
        {
            return base.ToString() + ", university: " + Location + ", " + Year + " years";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Student p = (Student)obj;
                return (Location == p.Location) && (Year == p.Year) && base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return ((base.GetHashCode() + Year) * 15) % Person.UniqueCode;
        }
    }
}

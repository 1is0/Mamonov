using System;

namespace CSlab3
{
     class Student : Person
    {
        public University Location { get; set; }
        public int Year { get; set; }
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
        static Student() { Console.WriteLine("The first instance of class Student was summoned"); }

        ~Student()
        {
            Console.WriteLine("Instance of class Student was deleted");
            Console.ReadKey();
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

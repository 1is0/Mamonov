using System;

namespace CSlab3
{
    class Student
    {
        public University Location { get; set; }
        public int Year { get; set; }
        public Person PersonalData { get; set; }

        public Student() { }
        public Student(University Location, int Year, int Age, string Name)
        {
            this.Location = Location;
            this.Year = Year;
            PersonalData = new Person(Age, Name);
        }
        public Student(University Location, int Year, Person PersonalData)
        {
            this.Location = Location;
            this.Year = Year;
            this.PersonalData = new Person(PersonalData.Age, PersonalData.Name);
        }
        static Student() { Console.WriteLine("The first instance of class Student was summoned"); }

        ~Student()
        {
            Console.WriteLine("Instance of class Student was deleted");
            Console.ReadKey();
        }

        public Student GetShallowCopy() { return (Student)this.MemberwiseClone(); }
        public Student GetDeepCopy() { return new Student(Location, Year, PersonalData.Age, PersonalData.Name); }

        public override string ToString()
        {
            return PersonalData.ToString() + ", university: " + Location + ", " + Year + " years";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Student p = (Student)obj;
                return (PersonalData.Age == p.PersonalData.Age) && (PersonalData.Name == p.PersonalData.Name) && (Location == p.Location) && (Year == p.Year);
            }
        }

        public override int GetHashCode()
        {
            return ((PersonalData.GetHashCode() + Year) * 15) % Person.UniqueCode;
        }
    }
}

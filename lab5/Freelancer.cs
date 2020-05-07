using System;

namespace CSlab3
{
    struct Freelancer  //can't be inherited by class
    {
        public Student Data;  //can't assign a value
        public string CurrentWork { get; set; }

        //public Freelancer() { };  - can't exist int struct
        public Freelancer(Student Data, string CurrentWork)
        {
            this.Data = Data;
            this.CurrentWork = CurrentWork;
        }

        public Freelancer(University Location, int Year, int Age, string Name, string CurrentWork)
        {
            Data = new Student(Location, Year, Age, Name);
            this.CurrentWork = CurrentWork;
        }

        public override string ToString()
        {
            return Data.ToString() + ", current work - " + CurrentWork;
        }

        public static void SwapWorks(ref Freelancer a, ref Freelancer b)
        {
            string temp = a.CurrentWork;
            a.CurrentWork = b.CurrentWork;
            b.CurrentWork = temp;
        }

        public string ToWork()
        {
            return $"{Data.Name} is working!!!";
        }
    }
}

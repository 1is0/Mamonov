using System;

namespace CSlab3
{
    struct Freelancer<T> : IWorkable  //can't be inherited by class
    {
        public Student Data;  //can't assign a value
        public string CurrentWork { get; set; }
        public int SpecialNumber { get; }

        //public Freelancer() { };  - can't exist int struct
        public Freelancer(Student Data, string CurrentWork)
        {
            this.Data = Data;
            this.CurrentWork = CurrentWork;
            SpecialNumber = 4;
        }

        public Freelancer(University Location, int Year, int Age, string Name, string CurrentWork)
        {
            Data = new Student(Location, Year, Age, Name);
            this.CurrentWork = CurrentWork;
            SpecialNumber = 4;
        }

        public new string GetType() { return typeof(T).ToString(); }

        public override string ToString()
        {
            return Data.ToString() + ", current work - " + CurrentWork;
        }

        public static void SwapWorks(ref Freelancer<T> a, ref Freelancer<T> b)
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

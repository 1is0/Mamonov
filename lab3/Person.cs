using System;

namespace CSlab3
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public static int UniqueCode { get; set; } = 0xAB;

        public Person(int Age, string Name) { this.Age = Age; this.Name = Name; }
        public Person(Person person) { this.Age = person.Age; this.Name = person.Name; }
        public Person() { }
        static Person() { Console.WriteLine("The first instance of class Person was summoned"); }

        ~Person()
        {
            Console.WriteLine("Instance of class Person was deleted");
            Console.ReadKey();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (Age == p.Age) && (Name == p.Name);
            }
        }

        public override int GetHashCode()
        {
            int res = 0;
            for (int i = 0; i < Name.Length; i++)
                res += (int)Name[i];
            return (Age + res) % UniqueCode;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", " + Age.ToString() + " years";
        }

    }
}

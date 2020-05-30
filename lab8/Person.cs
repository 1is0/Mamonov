namespace CSlab3
{
    abstract class Person
    {
        private int age;
        public int Age
        {
            get => age;
            set
            {
                if ((value > 0) && (value < 150))
                {
                    age = value;
                }
                else
                {
                    throw new ValueException("Incorrect age input", "age");
                }
            }
        }
        public string Name { get; set; }
        public static int UniqueCode { get; set; } = 0xAB;

        public Person(int Age, string Name) { this.Age = Age; this.Name = Name; }
        public Person(Person person) { Age = person.Age; Name = person.Name; }
        public Person() { }

        public abstract string Major { get; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
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
                res += Name[i];
            return (Age + res) % UniqueCode;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", " + Age.ToString() + " years";
        }

    }
}

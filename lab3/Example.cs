using System;

namespace CSlab3
{
    class Example
    {
        static void Main(string[] args)
        {
            Person a = new Person(33, "Jack");
            Console.WriteLine(a);
            Person b = new Person(33, "Jack");
            Console.WriteLine(a.Equals(b));  //True
            Console.WriteLine(a.GetHashCode());  //Hash code with basic unique code
            Person.UniqueCode = 23;
            Console.WriteLine(a.GetHashCode());  //Hash code with changed unique code
            Console.WriteLine();


            Student c = new Student(University.BSU, 2, a);
            Console.WriteLine(c);
            Student shallowCopy = c.GetShallowCopy();
            Student deepCopy = c.GetDeepCopy();
            Student simpleCopy = c;
            Console.WriteLine(c.Equals(simpleCopy)); // true
            Console.WriteLine(c.Equals(shallowCopy));  //true
            Console.WriteLine(c.Equals(deepCopy));  //true
            Console.WriteLine(ReferenceEquals(c,simpleCopy)); // true
            Console.WriteLine(ReferenceEquals(c, shallowCopy));  //false, ref !=
            Console.WriteLine(ReferenceEquals(c, deepCopy));  //false, ref !=
            c.PersonalData.Age = 18;
            Console.WriteLine(c.Equals(shallowCopy));  //true, because shallow copy can see only references, but data inside can not
            Console.WriteLine(c.Equals(deepCopy));  //false
            Console.WriteLine(c.GetHashCode());
            Console.WriteLine();

            Students list = new Students(3);
            list[0] = new Student(University.BSU, 20, 4, "Mark");
            list[1] = new Student(University.BSUIR, 19, 3, "John");
            list[2] = new Student(University.BSEU, 17, 1, "Linda");
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
            Console.WriteLine();

            Economist e = new Economist(list[0], 9);
            Economist f = new Economist(list[1], 8);
            Economist.SwapMarks(e, f);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(e.ToCry());
            Console.WriteLine();

            Engineer g = new Engineer(list[1], 6);
            Engineer h = new Engineer(list[0], 5);
            Engineer.SwapSkills(g, h);
            Console.WriteLine(g);
            Console.WriteLine(h);
            Console.WriteLine(g.ToRepairUniversity());
            Console.WriteLine();

            Programmer i = new Programmer(list[1], "blue");
            Programmer o = new Programmer(list[2], "red");
            Programmer.SwapGitHubLogins(i, o);
            Console.WriteLine(i);
            Console.WriteLine(o);
            Console.WriteLine(i.ToLearnCSharp());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}

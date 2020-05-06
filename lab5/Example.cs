using System;

namespace CSlab3
{
    class Example
    {
        static void Main(string[] args)
        {
            Student c = new Student(University.BSU, 2, 33, "Bob");
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
            c.Age = 18;
            Console.WriteLine(c.Equals(shallowCopy));  //false
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

            var e = new Economist(list[0], 9);
            var f = new Economist(list[1], 8);
            Economist.SwapMarks(e, f);
            Console.WriteLine(e);
            Console.WriteLine(f);
            e.ToCry();
            Console.WriteLine();

            var g = new Engineer(list[1], 6);
            var h = new Engineer(list[0], 5);
            Engineer.SwapSkills(g, h);
            Console.WriteLine(g);
            Console.WriteLine(h);
            g.ToRepairUniversity();
            Console.WriteLine();

            var i = new Programmer(list[1], "blue");
            var o = new Programmer(list[2], "red");
            Programmer.SwapGitHubLogins(i, o);
            Console.WriteLine(i);
            Console.WriteLine(o);
            i.ToLearnCSharp();
            Console.WriteLine();

            Console.WriteLine(i.Major);
            Console.WriteLine(g.Major);
            Console.WriteLine(e.Major);
            Console.WriteLine();

            var v = new Freelancer();
            var w = new Freelancer(list[0], "Design");
            var z = new Freelancer(list[2], "Mining");
            v = z;
            Console.WriteLine(z.Data.Equals(v.Data));  //True, struct is value type

            Console.WriteLine(w.ToString());
            Console.WriteLine(v.ToString());

            Freelancer.SwapWorks(ref w, ref v);

            Console.WriteLine(w.ToString());
            Console.WriteLine(v.ToString());

            Console.ReadKey();
        }
    }
}

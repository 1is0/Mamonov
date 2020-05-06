using System;

namespace CSlab3
{
    sealed class Programmer : Student
    {
        public string GitHubLogin { get; set; }
        public override string Major { get; } = "Programmer";

        public Programmer() : base() { }
        public Programmer(University Location, int Year, int Age, string Name, string GitHubLogin) : base(Location, Year, Age, Name)
        {
            this.GitHubLogin = GitHubLogin;
        }
        public Programmer(Student student, string GitHubLogin) : base(student)
        {
            this.GitHubLogin = GitHubLogin;
        }

        public override string ToString()
        {
            return base.ToString() + ", GitHub login : " + GitHubLogin;
        }

        public static void SwapGitHubLogins(Programmer a, Programmer b)
        {
            string temp = a.GitHubLogin;
            a.GitHubLogin = b.GitHubLogin;
            b.GitHubLogin = temp;
        }

        public void ToLearnCSharp()
        {
            Console.WriteLine("{0} is learning c#!!!", Name);
        }
    }
}

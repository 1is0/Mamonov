using System;

namespace CSlab3
{
    class Programmer
    {
        public Student Data { get; set; }
        public string GitHubLogin { get; set; }

        public Programmer() { }
        public Programmer(University Location, int Year, int Age, string Name, string GitHubLogin)
        {
            this.GitHubLogin = GitHubLogin;
            Data = new Student(Location, Year, Age, Name);
        }
        public Programmer(Student student, string GitHubLogin)
        {
            Data = student.GetDeepCopy();
            this.GitHubLogin = GitHubLogin;
        }

        public override string ToString()
        {
            return Data.ToString() + ", GitHub login : " + GitHubLogin;
        }

        public static void SwapGitHubLogins(Programmer a, Programmer b)
        {
            string temp = a.GitHubLogin;
            a.GitHubLogin = b.GitHubLogin;
            b.GitHubLogin = temp;
        }

        public void ToLearnCSharp()
        {
            Console.WriteLine("You are learning c#!!!");
        }
    }
}

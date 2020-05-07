using System;

namespace CSlab3
{
    sealed class Programmer<T> : Student, IWorkable
    {
        public string GitHubLogin { get; set; }
        public override string Major { get; } = "Programmer";
        public int SpecialNumber { get; } = 1;

        public Programmer() : base() { }
        public Programmer(University Location, int Year, int Age, string Name, string GitHubLogin) : base(Location, Year, Age, Name)
        {
            this.GitHubLogin = GitHubLogin;
        }
        public Programmer(Student student, string GitHubLogin) : base(student)
        {
            this.GitHubLogin = GitHubLogin;
        }

        public new string GetType() { return typeof(T).ToString(); }

        public override string ToString()
        {
            return base.ToString() + ", GitHub login : " + GitHubLogin;
        }

        public static void SwapGitHubLogins(Programmer<T> a, Programmer<T> b)
        {
            string temp = a.GitHubLogin;
            a.GitHubLogin = b.GitHubLogin;
            b.GitHubLogin = temp;
        }

        public void ToWork()
        {
            Console.WriteLine("{0} is learning c#!!!", Name);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !base.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Programmer<T> p = (Programmer<T>)obj;
                return (GitHubLogin == p.GitHubLogin) && base.Equals(obj);
            }
        }
    }
}

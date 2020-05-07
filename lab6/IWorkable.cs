namespace CSlab3
{
    interface IWorkable
    {
        int SpecialNumber { get; }

        string GetType();

        string ToString();

        bool Equals(object obj);

        void ToWork();
    }
}

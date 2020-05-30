namespace CSlab3
{
    interface IWorkable
    {
        int SpecialNumber { get; }

        string ToString();

        bool Equals(object obj);

        string ToWork();
    }
}

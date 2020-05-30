using System;

namespace CSlab3
{
    class ValueException : ArgumentException
    {
        public string Value { get; }

        public ValueException(string message, string Value) : base(message)
        {
            this.Value = Value;
        }
    }
}

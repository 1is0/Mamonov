using System;

namespace CSlab3
{
    class Students
    {
        private Student[] data;

        public Students(int Amount) { data = new Student[Amount]; }

        public Student this[int index]
        {
            get => data[index];
            set
            {
                data[index] = value;
            }
        }
    }
}

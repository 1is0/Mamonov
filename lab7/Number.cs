using System;

namespace CSLab7
{
    class Number : IComparable<Number>
    {
        private int N { get; set; }
        private int M { get; set; }

        public Number(int N, int M)
        {
            if (M <= 0)
            {
                throw new Exception("M is natural number");
            }
            ToCut(ref N, ref M);
            SetValues(N, M);          
        }
        public Number(Number number)
        {
            SetValues(N, M);
        }
        public Number(float number)
        {
            SetValues(((Number)number).N, M = ((Number)number).M);
        }
        public Number(double number)
        {
            SetValues(((Number)number).N, M = ((Number)number).M);
        }
        public Number(int number)
        {
            SetValues(((Number)number).N, M = ((Number)number).M);
        }

        public static implicit operator double(Number number)
        {
            return Convert.ToDouble(number.ToSingle());
        }
        public static implicit operator float(Number number)
        {
            return number.ToSingle();
        }
        public static implicit operator int(Number number)
        {
            return Convert.ToInt32(Math.Round((float)number));
        }
        public static implicit operator string(Number number)
        {
            return number.ToString();
        }
        public static implicit operator Number(float number)
        {
            int b = 1;
            while (number != Math.Truncate(number))
            {
                b *= 10;
                number *= 10;
            }
            int N = Convert.ToInt32(number);
            int M = b;
            ToCut(ref N, ref M);
            return new Number(N, M);
        }
        public static implicit operator Number(double number)
        {
            return new Number(Convert.ToSingle(number));
        }
        public static implicit operator Number(int number)
        {
            return new Number(Convert.ToSingle(number));
        }
        public static implicit operator Number(string number)
        {
            try
            {
                return new Number(Convert.ToSingle(number));
            }
            catch
            {
                throw new Exception("NaN");
            }
        }

        public static Number operator +(Number a, Number b)
        {
            long ar1 = Convert.ToInt64(a.N);
            long br1 = Convert.ToInt64(a.M);
            long ar2 = Convert.ToInt64(b.N);
            long br2 = Convert.ToInt64(b.M);
            ar1 = ar1 * br2 + br1 * ar2;
            br1 = br1 * br2;
            ToCut(ref ar1, ref br1);
            return new Number(Convert.ToInt32(ar1), Convert.ToInt32(br1));
        }
        public static Number operator -(Number a, Number b)
        {
            long ar1 = Convert.ToInt64(a.N);
            long br1 = Convert.ToInt64(a.M);
            long ar2 = Convert.ToInt64(b.N);
            long br2 = Convert.ToInt64(b.M);
            ar1 = ar1 * br2 - br1 * ar2;
            br1 = br1 * br2;
            ToCut(ref ar1, ref br1);
            return new Number(Convert.ToInt32(ar1), Convert.ToInt32(br1));
        }
        public static Number operator *(Number a, Number b)
        {
            long ar1 = Convert.ToInt64(a.N);
            long br1 = Convert.ToInt64(a.M);
            long ar2 = Convert.ToInt64(b.N);
            long br2 = Convert.ToInt64(b.M);
            ar1 = ar1 * ar2;
            br1 = br1 * br2;
            ToCut(ref ar1, ref br1);
            return new Number(Convert.ToInt32(ar1), Convert.ToInt32(br1));
        }
        public static Number operator /(Number a, Number b)
        {
            if (b == 0)
            {
                throw new Exception("division by 0 is impossible");
            }
            long ar1 = Convert.ToInt64(a.N);
            long br1 = Convert.ToInt64(a.M);
            long ar2 = Convert.ToInt64(b.N);
            long br2 = Convert.ToInt64(b.M);
            ar1 = ar1 * br2;
            br1 = br1 * ar2;
            ToCut(ref ar1, ref br1);
            return new Number(Convert.ToInt32(ar1), Convert.ToInt32(br1));
        }
        public static Number operator ++(Number a)
        {
            return new Number(Convert.ToInt32(a.N+=a.M), Convert.ToInt32(a.M));
        }
        public static Number operator --(Number a)
        {
            return new Number(Convert.ToInt32(a.N -= a.M), Convert.ToInt32(a.M));
        }
        public static bool operator ==(Number a, Number b) => a.Equals((object)b);
        public static bool operator !=(Number a, Number b) => !(a.Equals((object)b));
        public static bool operator >(Number a, Number b) => ((IComparable<Number>)a).CompareTo(b) == 1;
        public static bool operator <(Number a, Number b) => ((IComparable<Number>)b).CompareTo(a) == 1;
        public static bool operator >=(Number a, Number b) => ((IComparable<Number>)a).CompareTo(b) == 1 || a.Equals(b);
        public static bool operator <=(Number a, Number b) => ((IComparable<Number>)b).CompareTo(a) == 1 || b.Equals(a);

        public string DoubleView()
        {
            return ToString();
        }
        public string FactionView()
        {
            return $"{N}/{M}";
        }

        public override string ToString()
        {
            return ToSingle().ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() % 0xAB;
        }
        public override bool Equals(object other)
        {         
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return Equals(other as Number);
        }

        public bool Equals(Number other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            if (M.Equals(other.M) && N.Equals(other.N))
                return true;
            else
                return false;
        }


        int IComparable<Number>.CompareTo(Number obj)
        {
            return ToSingle() > obj.ToSingle() ? 1 : 0;
        }
        private float ToSingle()
        {
            return N / Convert.ToSingle(M);
        }
        private static void ToCut(ref int a, ref int b)
        {
            int i = 2;
            int max = a < b ? Math.Abs(a/2) : Math.Abs(b/2);
            while (i <= max) 
            {
                if (a % i == 0 && b % i == 0)
                {
                    a /= i;
                    b /= i;
                    i = 1;
                }
                i++;
            }
        }
        private static void ToCut(ref long a, ref long b)
        {
            long i = 2;
            long max = a < b ? Math.Abs(a / 2) : Math.Abs(b / 2);
            while (i <= max)
            {
                if (a % i == 0 && b % i == 0)
                {
                    a /= i;
                    b /= i;
                    i = 1;
                }
                i++;
            }
        }
        private void SetValues(int N, int M)
        {
            this.N = N;
            this.M = M;
        }
    }
}

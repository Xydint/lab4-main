using System;

namespace lab4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        public RomanNumber(ushort n)
        {
            int i;
            if (n == 0)
                throw new RomanNumberException("Constructor: n is equal to zero.");
            if (n >= 4000)
                throw new RomanNumberException("Constructor: n more than 3999.");
            Number = n;
            RomanString = "";
            for (i = 0; i < Arr_Size; ++i)
            {
                while (n - Values[i] >= 0)
                {
                    RomanString += Romans[i];
                    n -= Values[i];
                }
            }
        }
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Add: at least one object is null.");
            if (n1.Number + n2.Number >= 4000)
                throw new RomanNumberException("Add: sum exceeds 3999.");
            return new RomanNumber((ushort)(n1.Number + n2.Number));
        }
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Sub: at least one object is null.");
            if (n1.Number <= n2.Number)
                throw new RomanNumberException("Sub: result is less than or equal to zero.");
            return new RomanNumber((ushort)(n1.Number - n2.Number));
        }
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Mul: at least one object is null.");
            if (n1.Number * n2.Number >= 4000)
                throw new RomanNumberException("Mul: result exceeds 3999.");
            return new RomanNumber((ushort)(n1.Number * n2.Number));
        }
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Div: at least one object is null.");
            if (n1.Number / n2.Number == 0)
                throw new RomanNumberException("Div: result equals zero.");
            return new RomanNumber((ushort)(n1.Number / n2.Number));
        }
        public override string ToString()
        {
            return RomanString;
        }
        public object Clone()
        {
            return new RomanNumber(Number);
        }
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber)
                return this.Number.CompareTo(((RomanNumber)obj).Number);
            throw new RomanNumberException("CompareTo: obj is null or not RomanNumber.");
        }
        private static int Arr_Size = 13;
        private static string[] Romans =
            { "M", "CM", "D", "CD", "C", "XC", "L",
            "XL", "X", "IX", "V", "IV", "I" };
        private static ushort[] Values =
            {1000, 900, 500,
            400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private ushort Number;
        private string RomanString;
    }
}

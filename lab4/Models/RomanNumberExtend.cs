using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    internal class RomanNumberExtend : RomanNumber
    {
        public RomanNumberExtend(string num) : base(GetNumberFromString(num))
        {

        }
        private static ushort GetNumberFromString(string num)
        {
            CheckString(num);
            ushort result = 0;
            foreach (char c in num)
            {
                switch (c)
                {
                    case 'I':
                        result += 1;
                        break;
                    case 'V':
                        result += 5;
                        break;
                    case 'X':
                        result += 10;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'C':
                        result += 100;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'M':
                        result += 1000;
                        break;
                }
            }

            for (int i = 1; i < num.Length; i++)
            {
                if ((num[i] == 'V' || num[i] == 'X') && num[i - 1] == 'I')
                {
                    result -= 1 + 1;
                }

                if ((num[i] == 'L' || num[i] == 'C') && num[i - 1] == 'X')
                {
                    result -= 10 + 10;
                }

                if ((num[i] == 'D' || num[i] == 'M') && num[i - 1] == 'C')
                {
                    result -= 100 + 100;
                }
            }
            return result;
        }

        private static void CheckString(string num)
        {
            SortedDictionary<char, ushort> repeatedKeys = new SortedDictionary<char, ushort>();
            if (num is null) throw new RomanNumberException("Can't create roman number from string: string is null.");
            if (num.Length == 0) throw new RomanNumberException("Can't create roman number from string: string is empty.");
            foreach (char c in num)
            {
                if (!repeatedKeys.ContainsKey(c))
                    repeatedKeys.Add(c, 1);
            }
            for (int i = 1; i < num.Length; i++)
            {
                if (num[i] == num[i - 1]) repeatedKeys[num[i]]++;
                else repeatedKeys[num[i - 1]] = 1;
                if (repeatedKeys[num[i]] > 3)
                    throw new RomanNumberException("Can't create roman number from string: string has more than three repeated symbols.");
            }
        }
    }
}
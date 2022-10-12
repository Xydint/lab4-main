using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4.Models;

namespace lab4.ViewModels
{
    internal class RomanNumberCalculator
    {
        static internal string DoMath(string number, string number2, string command)
        {
            switch (command)
            {
                case "=":
                    return number2;
                case "+":
                    return (new RomanNumberExtend(number) + new RomanNumberExtend(number2)).ToString();
                case "-":
                    return (new RomanNumberExtend(number) - new RomanNumberExtend(number2)).ToString();
                case "*":
                    return (new RomanNumberExtend(number) * new RomanNumberExtend(number2)).ToString();
                case "/":
                    return (new RomanNumberExtend(number) / new RomanNumberExtend(number2)).ToString();
                default:
                    if (number2.Length > 0)
                    {
                        if (number2.Length >= 3)
                            if (number2[number2.Length - 3] == number2[number2.Length - 2] &&
                                number2[number2.Length - 2] == number2[number2.Length - 1] &&
                                number2[number2.Length - 2] == command[0])
                                return number2;
                        if (command == "V" || command == "L" || command == "D")
                            if (command[0] == number2[number2.Length - 1])
                                return number2;
                    }
                    return number2 + command;
            }
        }
    }
}

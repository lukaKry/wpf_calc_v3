using lukaKry_Calc_Library.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    internal static class CalculationTypeFactory
    {
        internal static ICalculation GetCalculationType(string symbol)
        {
            if (symbol == "+") return new Sum();
            if (symbol == "-") return new Subtraction();
            if (symbol == "*") return new Multiplication();
            if (symbol == "/") return new Division();
            
            throw new ArgumentException("The input symbol cannot be assigned to any known calculation type");

        }
    }
}

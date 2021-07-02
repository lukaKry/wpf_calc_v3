using System.Collections.Generic;
using System;

namespace lukaKry_Calc_Library.Logic
{
    internal class Equation
    {
        private List<ICalculation> _calculations = new();

        internal decimal Solve()
        {
            throw new NotImplementedException();
            // solves the whole current equation
            // foreach(var calc in _calculations) calc.Calculate()
        }
    }
}
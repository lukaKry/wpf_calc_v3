using System.Collections.Generic;

namespace Wpf_Calc_v3.Logic
{
    internal class Equation
    {
        private List<ICalculation> _calculations = new();

        public decimal Solve()
        {
            // solves the whole current equation
            // foreach(var calc in _calculations) calc.Calculate()
        }
    }
}
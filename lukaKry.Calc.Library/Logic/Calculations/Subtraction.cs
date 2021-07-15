using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic.Calculations
{
    class Subtraction : BaseCalculation, ICalculation
    {
        public decimal GetResult()
        {
            return Arg1.GetResult() - Arg2.GetResult();
        }

        public override string ToString()
        {
            return "-";
        }
    }
}

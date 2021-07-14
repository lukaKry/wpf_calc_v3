using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.Calculations
{
    class Multiplication : BaseCalculation, ICalculation
    {
        public decimal GetResult()
        {
            return Arg1.GetResult() * Arg2.GetResult();
        }

        public override string ToString()
        {
            return "*";
        }
    }
}

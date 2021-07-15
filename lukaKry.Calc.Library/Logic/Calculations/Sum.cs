using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("lukaKry.Calc.Library.UnitTests")]
namespace lukaKry.Calc.Library.Logic.Calculations
{
    internal class Sum : BaseCalculation, ICalculation
    {
        public decimal GetResult()
        {
            return Arg1.GetResult() + Arg2.GetResult();
        }

        public override string ToString()
        {
            return "+";
        }
    }
}

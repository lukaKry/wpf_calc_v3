using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic.Calculations
{
    public class BaseCalculation : ISettableCalculation
    {
        public ICalculation Arg1 { get; set; }
        public ICalculation Arg2 { get; set; }

        public BaseCalculation()
        {
            Arg1 = new Number(0);
            Arg2 = new Number(0);
        }
    }
}

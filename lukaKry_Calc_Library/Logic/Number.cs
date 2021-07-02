using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    internal class Number : ICalculation
    {
        private decimal _arg1;

        decimal ICalculation.GetResult()
        {
            return _arg1;
        }
        public Number(decimal arg)
        {
            _arg1 = arg;
        }

    }
}

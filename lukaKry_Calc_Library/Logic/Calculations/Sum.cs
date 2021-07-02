using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("lukaKry_Calc_Library.UnitTests")]
namespace lukaKry_Calc_Library.Logic.Calculations
{
    internal class Sum : ICalculation
    {
        private ICalculation _arg1;
        private ICalculation _arg2;

        public decimal GetResult()
        {
            return _arg1.GetResult() + _arg2.GetResult();
        }

        internal void SetArg1(ICalculation arg)
        {
            _arg1 = arg;
        }

        internal void SetArg2(ICalculation arg)
        {
            _arg2 = arg;
        }
    }
}

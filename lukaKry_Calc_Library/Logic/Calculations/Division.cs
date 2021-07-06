using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.Calculations
{
    class Division : ICalculation
    {
        private ICalculation _divisor;

        public ICalculation Arg1 { get; set; }
        public ICalculation Arg2 
        {
            get
            {
                return _divisor;
            }
            set 
            {
                if (value.GetResult() == 0)
                    throw new DivideByZeroException();
                _divisor = value;
            }
        }

        public Division()
        {
            Arg2 = new Number(1);
            Arg1 = new Number(0);
        }
        public decimal GetResult()
        {
            return Arg1.GetResult() / Arg2.GetResult();
        }
    }
}

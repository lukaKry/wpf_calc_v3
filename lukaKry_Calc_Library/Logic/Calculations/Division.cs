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

        public ICalculation Dividend { get; set; }
        public ICalculation Divisor 
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
            Divisor = new Number(1);
            Dividend = new Number(0);
        }
        public decimal GetResult()
        {
            return Dividend.GetResult() / Divisor.GetResult();
        }
    }
}

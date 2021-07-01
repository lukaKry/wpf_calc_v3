using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Wpf.Logic.Calculations
{
    public class Subtraction : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            // co jeśli nie ma jeszcze _arg1 i _arg2 ?
            return _arg1 - _arg2;
        }

        public void SetArgs(decimal x, decimal y)
        {
            _arg1 = x;
            _arg2 = y;
        }

        public override string ToString()
        {
            return $"{_arg1} - {_arg2} = {Calculate()}";
        }
    }
}

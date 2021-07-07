using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    public class SimpleCalculationBuilder : ICalculationBuilder
    {
        private Dictionary<string, Func<ICalculation>> _dictionary;
        private ISettable _calculation;
        private Number _arg1;
        private Number _arg2;

        public void AddCalculation(ISettable calculation)
        {
            _calculation = calculation;
        }

        public void AddNumber(decimal number)
        {
            if (_arg1 is null)
            {
                _arg1 = new Number(number);
            }
            else
            {
                _arg2 = new Number(number);
            }
        }

        public ICalculation Build()
        {
            if (_arg1 is null || _arg2 is null)
            {
                throw new InvalidOperationException("Set both arguments before build");
            }

            _calculation.Arg1 = _arg1;
            _calculation.Arg2 = _arg2;

            return _calculation as ICalculation;
        }
    }
}

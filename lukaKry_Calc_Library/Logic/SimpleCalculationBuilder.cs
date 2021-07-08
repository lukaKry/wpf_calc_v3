using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    // change builder to generic one; eventually 
    //public class SimpleCalculationBuilder<T> : ICalculationBuilder where T : ISettableCalculation, new() // to co jest na prawo od "where" to tak jakby wymagania do T; takie warunki 

    public class SimpleCalculationBuilder : ICalculationBuilder 
    {
        private ISettableCalculation _calculation;
        private Number _arg1;
        private Number _arg2;

        public SimpleCalculationBuilder()
        {
            //_calculation = new T();
        }

        public void AddCalculation(ISettableCalculation calculation)
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

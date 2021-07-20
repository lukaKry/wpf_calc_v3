using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic.CalculationsBuilders
{
    public class ExtendedCalculationBuilder : ICalculationBuilder
    {
        private ISettableCalculation _calc;
        private ICalculation _Arg1;
        private ICalculation _Arg2;
        // moze jakies pole boolean typu isBuilt; na wypadek podwojnego wywolania metody build()

        public void AddCalculation(ISettableCalculation calculation)
        {
            if (_calc is null)
            {
                _calc = calculation;
            }
            else
            {
                // same priority
                _Arg1 = _calc as ICalculation;
                _calc = calculation;
                _Arg2 = null;
            }
        }

        public void AddNumber(decimal number)
        {
            if (_Arg1 is null)
            {
                _Arg1 = new Number(number);
            }
            else
            {
                _Arg2 = new Number(number);
                _calc.Arg2 = _Arg2;
                Build();
            }
        }

        public ICalculation Build()
        {
            if (_Arg1 is null || _Arg2 is null || _calc is null)
            {
                // add logger here
                throw new InvalidOperationException("Cannot build uncompleted calculation.");
            }

            _calc.Arg1 = _Arg1;
            _calc.Arg2 = _Arg2;

            return _calc as ICalculation;
        }


        public override string ToString()
        {
            var calc = _calc as ICalculation;
            return $"{_Arg1.ToShortString()} {calc.GetSymbol()} {_Arg2.ToShortString()} = {calc.GetResult()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic
{
    public class SimpleCalculationBuilder : ICalculationBuilder
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private ISettableCalculation _calc;
        private Number _Arg1;
        private Number _Arg2;

        public void AddCalculation(ISettableCalculation calculation)
        {
            _calc = calculation;
        }

        public void AddNumber(decimal number)
        {
            if (_Arg1 is null)
            {
                Logger.Info("Number has been assigned at the position 1");
                _Arg1 = new Number(number);
            }
            else
            {
                Logger.Info("Number has been assigned at the position 2");
                _Arg2 = new Number(number);
            }
        }

        public ICalculation Build()
        {

            if (_Arg1 is null || _Arg2 is null || _calc is null)
            {
                Logger.Error("Invalid operation: not all arguments have been set before build");
                throw new InvalidOperationException("Set both arguments and calculation type before build");
            }

            _calc.Arg1 = _Arg1;
            _calc.Arg2 = _Arg2;

            Logger.Info("Calculation: {calculation} has been successfully built", this);
            return _calc as ICalculation;
        }

        public override string ToString()
        {
            if(_calc is null)
            {
                Logger.Error("Invalid operation: Add Calculation first before calling ToString method");
                throw new InvalidOperationException("Calculation is null");
            }
            ICalculation calc = _calc as ICalculation;

            return $"{_calc.Arg1} {calc.GetSymbol()} {_calc.Arg2} = {calc.GetResult()}";
        }

        public void Reset()
        {
            _calc = null;
            _Arg1 = null;
            _Arg2 = null;
        }
    }
}

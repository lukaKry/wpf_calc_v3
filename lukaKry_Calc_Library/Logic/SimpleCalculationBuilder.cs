using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    public class SimpleCalculationBuilder : ICalculationBuilder 
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
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
                Logger.Info("Number has been assigned at the position 1");
                _arg1 = new Number(number);
            }
            else
            {
                Logger.Info("Number has been assigned at the position 2");
                _arg2 = new Number(number);
            }
        }

        public ICalculation Build()
        {
            if (_arg1 is null || _arg2 is null)
            {
                Logger.Error("Invalid operation: not all arguments have been set before build");
                throw new InvalidOperationException("Set both arguments before build");
            }

            _calculation.Arg1 = _arg1;
            _calculation.Arg2 = _arg2;

            Logger.Info("Calculation: {calculation} has been successfully built", this);
            return _calculation as ICalculation;
        }

        public override string ToString()
        {
            ICalculation calc = _calculation as ICalculation;

            return $"{_calculation.Arg1} {calc} {_calculation.Arg2} = {calc.GetResult()}";
        }
    }
}

﻿using lukaKry.Calc.Library.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic.CalculationsBuilders
{
    public class AdvancedCalculationBuilder : ICalculationBuilder
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private ISettableCalculation _calc;
        private ICalculation _Arg1;
        private ICalculation _Arg2;

        public void AddCalculation(ISettableCalculation calculation)
        {
            if (_calc is null)
            {
                _calc = calculation;
            }
            else
            {
                var newCalc = calculation as IPrioritizableCalculation;
                var oldCalc = _calc as IPrioritizableCalculation;

                if (newCalc.Priority <= oldCalc.Priority)
                {// jesli priorytet nastepnego rownania jest mniejszy lub taki sam
                    _Arg1 = _calc as ICalculation;
                    _calc = calculation;
                    _Arg2 = null;
                }
                else
                {// jesli priorytet nastepnego rownania jest wiekszy
                    calculation.Arg1 = _calc.Arg2;
                    _Arg2 = calculation as ICalculation;
                    _calc.Arg2 = null;
                }
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
                if (_calc.Arg2 is null)
                {
                    var settable = _Arg2 as ISettableCalculation;
                    settable.Arg2 = new Number(number);
                }
                else
                {
                    _Arg2 = new Number(number);
                }
                Build();
            }
        }

        public ICalculation Build()

        {
            if (_Arg1 is null || _Arg2 is null || _calc is null)
            {
                _logger.Error("Invalid operation: not all arguments have been set before build");
                throw new InvalidOperationException("Cannot build uncompleted calculation.");
            }

            _calc.Arg1 = _Arg1;
            _calc.Arg2 = _Arg2;

            return _calc as ICalculation;
        }


        public override string ToString()
        {
            if (_calc is null)
            {
                _logger.Error("Invalid operation: Add Calculation first before calling ToString method");
                throw new InvalidOperationException("Calculation is null");
            }

            var calc = _calc as ICalculation;
            return $"{_Arg1} {calc.GetSymbol()} {_Arg2} = {calc.GetResult()}";
        }
    }
}
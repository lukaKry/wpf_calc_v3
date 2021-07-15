using System.Collections.Generic;
using System;
using lukaKry_Calc_Library.Logic.Calculations;

namespace lukaKry_Calc_Library.Logic
{
    public class Calculator
    {
        ICalculation _currentCalculation;
        ICalculationBuilder _builder;

        public ICalculation CurrentCalculation 
        { 
            get 
            {
                return _currentCalculation;
            }
        }

        public Calculator(ICalculationBuilder builder = null)
        {
            _builder = builder ?? new SimpleCalculationBuilder();
        }

        public decimal GetResult()
        {
            _currentCalculation = _builder.Build();
            return _currentCalculation.GetResult();
        }

        public void ResetCurrentCalculation()
        {
            _currentCalculation = null;
        }
    }
}
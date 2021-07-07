using System.Collections.Generic;
using System;
using lukaKry_Calc_Library.Logic.Calculations;

namespace lukaKry_Calc_Library.Logic
{
    public class Calculator
    {
        ICalculation _currentCalculation;
        IRegistry _calculationsRegistry;
        ICalculationBuilder _builder;

        public Calculator(IRegistry registry, ICalculationBuilder builder)
        {
            _calculationsRegistry = registry;
            _builder = builder;
        }

        public void AddCalculationToRegistry(ICalculation calc)
        {
            _calculationsRegistry.AddItemToRegistry(calc);
        }

        public ICalculation GetLastCalculationFromRegistry()
        {
            return _calculationsRegistry.GetLastItemFromRegistry();
        }

        public decimal GetResult()
        {
            try
            {
                _currentCalculation = _builder.Build();
            }
            catch ( Exception ex )
            {
                throw new InvalidOperationException(ex.Message);
            }
            return _currentCalculation.GetResult();
        }

        public void ResetCurrentCalculation()
        {
            _currentCalculation = null;
        }
    }
}
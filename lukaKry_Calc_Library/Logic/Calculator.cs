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

        public ICalculation CurrentCalculation 
        { 
            get 
            {
                return _currentCalculation;
            }
        }

        public Calculator(IRegistry registry = null, ICalculationBuilder builder = null)
        {
            _calculationsRegistry = registry ?? new RegistrySimple();
            _builder = builder ?? new SimpleCalculationBuilder();
        }

        public void SaveCalculation(ICalculation calc)
        {
            _calculationsRegistry.AddItem(calc);
        }

        public ICalculation RestoreCalculation()
        {
            try 
            {
                return _calculationsRegistry.GetLastItem();
            }
            catch
            {
                throw new InvalidOperationException();
            }
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

        // dodać publiczny getter do pola _currentCalculation
    }
}
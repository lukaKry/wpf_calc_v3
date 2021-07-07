using System.Collections.Generic;
using System;
using lukaKry_Calc_Library.Logic.Calculations;

namespace lukaKry_Calc_Library.Logic
{
    public class Calculator
    {
        ICalculation _currentCalculation;
        IRegistry _calculationsRegistry;

        public Calculator(IRegistry registry)
        {
            _calculationsRegistry = registry;
        }

        public void AddCalculationToRegistry(ICalculation calc)
        {
            _calculationsRegistry.AddItemToRegistry(calc);
        }

        public ICalculation GetLastCalculationFromRegistry()
        {
            return _calculationsRegistry.GetLastItemFromRegistry();
        }

        public void EditCalculationAddNumber(decimal num)
        {
            // trzy opcje 

            // 1 - _currentCalculation is null      ustaw nowa instancje obiektu typu Number

            // 2 - _currentCalculation is Number    - zmien argument na nowo wprowadzony

            // 3 - _currentCalculation is Sum, Subtraction, Multiplication, Division    -  ustaw nowa instancje obiektu jako argument1 istniejacego obiektu

            if (_currentCalculation is null)
            {
                _currentCalculation = new Number(num);
            }
            else
            {
                if (_currentCalculation is Number)
                {
                    _currentCalculation = new Number(num);
                }
                else
                {
                    _currentCalculation.Arg2 = new Number(num);
                }
            }
        }

        public void AddCalculationType(string symbol)
        {
            // trzy opcje 

            // 1 - _currentCalculation is null      ustaw nowa instancje obiektu typu Icalculation  -- >> moze jednak factory method

            // 2 - _currentCalculation is Number    - ustaw nowa instancje obiektu typu ICalculation, ale dopisz do niej jeszcze wartosc ze starego numeru

            // 3 - _currentCalculation is Sum, Subtraction, Multiplication, Division    -  ustaw nowa instancje obiektu jako argument1 istniejacego obiektu
            

            if(_currentCalculation is null)
            {
                _currentCalculation = CalculationTypeFactory.GetCalculationType(symbol);
            }
            else
            {
                if(_currentCalculation is Number)
                {
                    decimal oldArgument = _currentCalculation.GetResult();
                    _currentCalculation = CalculationTypeFactory.GetCalculationType(symbol);
                    _currentCalculation.Arg1 = new Number(oldArgument);
                }
                else
                {
                    _currentCalculation.Arg2 = CalculationTypeFactory.GetCalculationType(symbol);
                }
            }
        }

        public decimal GetResult()
        {
            if (_currentCalculation is null) throw new InvalidOperationException();

            return _currentCalculation.GetResult();
        }

        public void ResetCurrentCalculation()
        {
            _currentCalculation = null;
        }

        public void testmethod()
        {
            // this is test method
        }
    }
}
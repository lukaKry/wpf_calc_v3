using System.Collections.Generic;
using System;

namespace lukaKry_Calc_Library.Logic
{
    internal class Calculator
    {
        Equation _currentEquation = new();
        List<Equation> _equationsHistory = new();

        internal void ResetEquation()
        {
            _currentEquation = new();
        }

        internal void AddCurrentEquationToHistory()
        {
            _equationsHistory.Add(_currentEquation);
        }

        internal Equation GetLastEquation()
        {
            // if _equationsHistory is not empty
            return _equationsHistory[^1];
        }

        internal decimal GetResult()
        {
            throw new NotImplementedException();
            //return _currentEquation.Solve();
        }
    }
}
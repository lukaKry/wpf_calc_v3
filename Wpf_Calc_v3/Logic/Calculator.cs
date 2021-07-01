using System.Collections.Generic;
using System;

namespace lukaKry_Calc_Wpf.Logic
{
    internal class Calculator
    {
        private Equation _currentEquation = new();
        private List<Equation> _equationsHistory = new();

        internal void ResetEquation()
        {
            _currentEquation = new();
        }

        // jaka jest praktyczna różnica miedzy internal a public ( bo teoria teorią, a jak to wyglada w praktyce )
        internal void AddCurrentEquationToHistory()
        {
            _equationsHistory.Add(_currentEquation);
        }

        public Equation GetLastEquation()
        {
            // if _equationsHistory is not empty
            return _equationsHistory[^1];
        }

        public decimal GetResult()
        {
            throw new NotImplementedException();
            //return _currentEquation.Solve();
        }
    }
}
using System.Collections.Generic;

namespace Wpf_Calc_v3.Logic
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
            //return _currentEquation.Solve();
        }
    }
}
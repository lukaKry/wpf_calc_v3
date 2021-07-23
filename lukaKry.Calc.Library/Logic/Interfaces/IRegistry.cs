using System.Collections.Generic;

namespace lukaKry.Calc.Library.Logic
{
    public interface IRegistry
    {
        ICalculation GetLastCalculation();
        void AddCalculation(ICalculation calc);
        IEnumerable<string> GetAll();
    }
}
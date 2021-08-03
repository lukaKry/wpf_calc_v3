using lukaKry.Calc.Library.Logic.Calculations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic
{
    public interface IRegistry
    {
        Task<Equation> GetLastCalculation();
        Task AddCalculation(Equation equation);
        Task<IEnumerable<ICalculation>> GetAll();
    }
}
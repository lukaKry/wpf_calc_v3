using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using lukaKry.Calc.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Interfaces
{
    public interface IRegistry
    {
        Task<Equation> GetLastCalculation();
        Task AddCalculation(Equation equation);
        Task<IEnumerable<ICalculation>> GetAll();
        Task<EquationDTO> AddEquation(EquationDTO equation);
    }
}
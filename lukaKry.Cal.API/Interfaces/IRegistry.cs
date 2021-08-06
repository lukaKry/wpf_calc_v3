using lukaKry.Calc.API.Models;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.API
{
    public interface IRegistry
    {
        Task<Equation> GetLastCalculation();
        Task AddCalculation(Equation equation);
        Task<IEnumerable<ICalculation>> GetAll();
        Task<EquationDTO> AddEquation(EquationDTO equation);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic
{
    public interface IRegistry
    {
        Task<ICalculation> GetLastCalculation();
        Task AddCalculation(ICalculation equation);
        Task<IEnumerable<ICalculation>> GetAll();
    }
}
using lukaKry.Calc.Library.Logic;
using System.Collections.Generic;

namespace lukaKry.Calc.API.Services
{
    public interface ICalculatorService
    {
        void AddCalculation(CalculationType type);
        void AddNumber(decimal number);
        IEnumerable<string> GetAllCalculationRecords();
        decimal GetResult();
        void ResetBuilder();
    }
}
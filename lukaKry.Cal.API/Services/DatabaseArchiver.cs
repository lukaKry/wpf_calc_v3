using lukaKry.Calc.API.DataAccess;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaKry.Calc.API.Services
{
    public class DatabaseArchiver : IRegistry
    {
        private readonly CalculationDataContext _context;
        public DatabaseArchiver(CalculationDataContext context) => _context = context;


        public async Task AddCalculation(Equation calc)
        {
            string jsonCalc = JsonConvert.SerializeObject(calc, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            await _context.CalculationRecords.AddAsync(new CalculationRecord()
            {
                Calculation = jsonCalc
            });

            await _context.SaveChangesAsync();
        }

        
        public async Task<IEnumerable<ICalculation>> GetAll()
        {
            throw new NotImplementedException();
           // _context.CalculationRecords.Select(p => p.Calculation);

        }

        public async Task<Equation> GetLastCalculation()
        {
            string serializedCalc = _context.CalculationRecords.OrderBy(p => p.Id).Last().Calculation;

            var equation = JsonConvert.DeserializeObject<Equation>(serializedCalc, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            return equation;
        }

        public string GetTest()
        {
            return _context.CalculationRecords.Last().Calculation;
        }
    }
}
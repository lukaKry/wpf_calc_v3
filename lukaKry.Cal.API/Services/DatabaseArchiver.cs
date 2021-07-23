using lukaKry.Calc.API.DataAccess;
using lukaKry.Calc.Library.Logic;
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


        public void AddCalculation(ICalculation calc)
        {
            // jeśli chciałbym zmienić to na metody asynchroniczne, to mój interfejs staje się nieopdowiedni... co można z tym zrobić? 
            _context.CalculationRecords.Add(new CalculationRecord()
            {
                Calculation = $"{calc} = {calc.GetResult()}"
            });

            _context.SaveChanges();
        }

        public IEnumerable<string> GetAll()
        {
            return _context.CalculationRecords.Select(p => p.Calculation);
        }

        public ICalculation GetLastCalculation()
        {
            // no i robi sie problematycznie - jak zapisac do bazy danych obiekt typu ICalculation tak, by potem mozna go bylo spokojnie wyciagnac
            throw new NotImplementedException();
        }
    }
}

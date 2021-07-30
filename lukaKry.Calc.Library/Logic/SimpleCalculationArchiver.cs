﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic
{
    public class SimpleCalculationArchiver : IRegistry
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private List<ICalculation> _archive = new();


        public async Task AddCalculation(ICalculation calculation)
        {
            Logger.Info("Calculation archived successfully.");
            _archive.Add(calculation);
        }

        public async Task<ICalculation> GetLastCalculation()
        {
            if (!_archive.Any())
            {
                Logger.Error("An attempt to get last item from empty list was made.");
                throw new InvalidOperationException();
            }
            return _archive.Last();
        }

        public async Task<IEnumerable<ICalculation>> GetAll()
        {
            return _archive;
        }
    }
}

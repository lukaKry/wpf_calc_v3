using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic
{
    public class SimpleCalculationArchiver
    {
        // ta klasa rownie dobrze moze przechowywac referencje typu IRegistry
        // wowczas mozna do niej wstrzyknac dowolny sposob przechowywania danych z interfejsem IRegister

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static List<string> _archive = new();


        public void SaveCalculation(string calculation)
        {
            Logger.Info("Calculation archived successfully.");
            _archive.Add(calculation);
        }

        public string GetLastCalculation()
        {
            if (!_archive.Any())
            {
                Logger.Error("An attempt to get last item from empty list was made.");
                throw new InvalidOperationException();
            }
            return _archive.Last();
        }

        public IEnumerable<string> GetAllCalculations()
        {
            return _archive;
        }
    }
}

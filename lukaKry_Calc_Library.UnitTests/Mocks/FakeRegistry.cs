using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.UnitTests.Mocks
{
    class FakeRegistry : IRegistry
    {
        public void AddItemToRegistry(ICalculation calc)
        {
            throw new NotImplementedException();
        }

        public ICalculation GetLastItemFromRegistry()
        {
            return new Sum();
        }
    }
}

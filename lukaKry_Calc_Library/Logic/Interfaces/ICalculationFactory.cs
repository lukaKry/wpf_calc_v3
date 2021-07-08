using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.Interfaces
{
    public interface ICalculationFactory
    {
        ISettableCalculation Create();
    }
}

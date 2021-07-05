﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.Calculations
{
    public class BaseCalculation
    {
        internal ICalculation Arg1 { get; set; }
        internal ICalculation Arg2 { get; set; }

        public BaseCalculation()
        {
            Arg1 = new Number(0);
            Arg2 = new Number(0);
        }
    }
}

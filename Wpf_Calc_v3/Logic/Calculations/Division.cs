﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Calc_v3.Logic.Calculations
{
    public class Division : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            // co jeśli nie ma jeszcze _arg1 i _arg2 ?
            return _arg1 / _arg2;
        }

        public void SetArgs(decimal x, decimal y)
        {
            _arg1 = x;

            // tutaj powinnien byc jakis check, czy drugi argument nie jest zerowy
            _arg2 = y;
        }

        public override string ToString()
        {
            return $"{_arg1} / {_arg2} = {Calculate()}";
        }
    }
}
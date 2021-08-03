using lukaKry.Calc.Library.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lukaKry.Calc.API.DataAccess
{
    public class CalculationRecord
    {
        public int Id { get; set; }

        [MaxLength(5000)]
        public string Calculation { get; set; }
    }
} 

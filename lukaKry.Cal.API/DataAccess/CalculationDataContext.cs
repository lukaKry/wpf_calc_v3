using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaKry.Calc.API.DataAccess
{
    public class CalculationDataContext : DbContext
    {
        public CalculationDataContext(DbContextOptions<CalculationDataContext> options) : base(options)
        { }

        public DbSet<CalculationRecord> CalculationRecords { get; set; }
    }
}

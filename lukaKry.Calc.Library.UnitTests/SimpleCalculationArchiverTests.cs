using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.UnitTests
{
    public class SimpleCalculationArchiverTests
    {
        
        
        [Test]
        public async Task AddCalculation_WhenCalled_StoresCalculation()
        {
            var archiver = new SimpleCalculationArchiver();

            await archiver.AddCalculation(new Equation(new List<ISettableCalculation>(), new List<decimal>()));

            var result = await archiver.GetLastCalculation();

            Assert.That(result.GetResult(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetLastCalculation_EmptyArchive_ThrowsInvalidOperationException()
        {
            var archiver = new SimpleCalculationArchiver();

            Assert.That(async () => await archiver.GetLastCalculation(), Throws.InvalidOperationException);
        }

        [Test]
        public async Task GetAllCalculations()
        {
            var archiver = new SimpleCalculationArchiver();

            var result = await archiver.GetAll();

            Assert.That(result, Is.InstanceOf<IEnumerable<ICalculation>>());
        }
    }
}

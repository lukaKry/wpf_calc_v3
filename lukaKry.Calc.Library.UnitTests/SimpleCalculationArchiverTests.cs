using lukaKry.Calc.Library.Logic;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests
{
    public class SimpleCalculationArchiverTests
    {
        [Test]
        public void SaveCalculation_WhenCalled_StoresCalculation()
        {
            var archiver = new SimpleCalculationArchiver();

            archiver.AddCalculation(new Number(1));

            var result = archiver.GetLastCalculation().GetResult();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetLastCalculation_EmptyArchive_ThrowsInvalidOperationException()
        {
            var archiver = new SimpleCalculationArchiver();

            Assert.That(() => archiver.GetLastCalculation(), Throws.InvalidOperationException);
        }
    }
}

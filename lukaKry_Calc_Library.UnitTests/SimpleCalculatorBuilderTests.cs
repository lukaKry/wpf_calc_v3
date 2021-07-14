using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry_Calc_Library.UnitTests
{
    public class SimpleCalculatorBuilderTests
    {
        [Test]
        public void ToString_WhenCalled_ReturnsCalculationParsedToString()
        {
            var builder = new SimpleCalculationBuilder();
            builder.AddCalculation(new Sum() 
            {
                Arg1 = new Number(1),
                Arg2 = new Number(1)
            });
            var result = builder.ToString();

            Assert.That(result, Is.EqualTo("1 + 1 = 2"));
        }
    }
}

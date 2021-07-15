using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests
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

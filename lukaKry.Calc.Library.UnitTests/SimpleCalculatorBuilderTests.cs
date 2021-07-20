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

        [Test]
        [TestCase(CalculationType.Sum, "+")]
        [TestCase(CalculationType.Subtraction, "-")]
        [TestCase(CalculationType.Division, "/")]
        [TestCase(CalculationType.Multiplication, "*")]
        public void AddCalculation_WhenCalled_AddsApropriateSymbolSignToOutputString(CalculationType type, string output)
        {
            var builder = new SimpleCalculationBuilder();
            var factory = new CalculationsFactoryProvider();    // czy to jest ok, wykorzystywac zaleznosc od innych klas?

            builder.AddCalculation(factory[type].Create());

            var checkString = builder.ToString();

            Assert.That(checkString, Does.Contain(output));
        }

        [Test]
        public void AddNumber_AddTwoNumbers_OutputStringContainsAddedNumberOnCorrectPositions()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddNumber(2);
            builder.AddCalculation(new Sum());
            builder.Build();
            var checkString = builder.ToString();

            Assert.That(checkString.StartsWith("1"));
            Assert.That(checkString.Contains("2"));
        }

        [Test]
        public void AddNumber_AddMultipleNumbers_OutputStringContainsFirstAndLastInputNumber()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddNumber(2);
            builder.AddNumber(3);
            builder.AddCalculation(new Sum());
            builder.Build();
            var checkString = builder.ToString();

            Assert.That(checkString.StartsWith("1"));
            Assert.That(checkString.Contains("3"));
        }

        [Test]
        public void Build_CalculationIsNull_ThrowsInvalidOperationException()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddNumber(1);

            Assert.That( () => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument1isnull_ThrowsInvalidOperationException()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument2isnull_ThrowsInvalidOperationException()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }
    }
}

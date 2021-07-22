using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests
{
    public class SimpleCalculatorBuilderTests
    {
        [Test]
        [TestCase(CalculationType.Sum, "+")]
        [TestCase(CalculationType.Subtraction, "-")]
        [TestCase(CalculationType.Division, "/")]
        [TestCase(CalculationType.Multiplication, "*")]
        public void AddCalculation_WhenCalled_AddsApropriateSymbolSignToOutputString(CalculationType type, string output)
        {
            var builder = new SimpleCalculationBuilder();
            var factory = new CalculationsFactoryProvider();

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

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObject()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result, Is.InstanceOf<ICalculation>());
        }

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObjectWithCorrectArgs()
        {
            var builder = new SimpleCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result.GetResult(), Is.EqualTo(2));
        }

        [Test]
        public void ToString_CalculationFieldIsNull_ThrowsInvalidOparationException()
        {
            var builder = new SimpleCalculationBuilder();

            Assert.That(() => builder.ToString(), Throws.InvalidOperationException);
        }

        [Test]
        public void ToString_CalculationIsSet_ReturnsCorrectlyFormatedString()
        {
            var builder = new SimpleCalculationBuilder();
            builder.AddCalculation(new Sum()
            {
                Arg1 = new Number(1),
                Arg2 = new Number(2)
            });
            var result = builder.ToString();

            Assert.That(result, Is.EqualTo("1 + 2 = 3"));
        }
    }
}

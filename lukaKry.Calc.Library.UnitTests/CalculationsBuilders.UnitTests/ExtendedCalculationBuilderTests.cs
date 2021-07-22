using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using lukaKry.Calc.Library.Logic.CalculationsBuilders;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests.CalculationsBuildersTests
{
    public class ExtendedCalculationBuilderTests
    {
        [Test]
        public void AddCalculation_FirstSumCalculationIsSum_OutputStringContainsPlusSymbol()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);
            
            var result = builder.ToString();

            Assert.That(result, Does.Contain("+"));
            Assert.That(result[2], Is.EqualTo('+'));
        }

        [Test]
        public void AddCalculation_SecondSumCalculation_OutputStringContainsTwoPlusSymbols()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);
            builder.AddCalculation(new Sum());
            builder.AddNumber(3);

            var result = builder.ToString();

            Assert.That(result.Count(q => q == '+'), Is.EqualTo(2));
        }

        [Test]
        [TestCase(CalculationType.Subtraction, '-')]
        [TestCase(CalculationType.Sum, '+')]
        [TestCase(CalculationType.Division, '/')]
        [TestCase(CalculationType.Multiplication, '*')]

        public void AddCalculation_TripleCalculations_OutputStringContainsCorrectCalculationSymbols(CalculationType type, char symbol)
        {
            var builder = new ExtendedCalculationBuilder();
            var factory = new CalculationsFactoryProvider();

            builder.AddNumber(3);
            builder.AddCalculation(factory[type].Create());
            builder.AddNumber(1);
            builder.AddCalculation(factory[type].Create());
            builder.AddNumber(1);
            builder.AddCalculation(factory[type].Create());
            builder.AddNumber(1);

            var result = builder.ToString();

            Assert.That(result.Count(q => q == symbol), Is.EqualTo(3));
        }

        [Test]
        public void AddNumber_AddTwoNumbers_OutputStringContainsAddedNumberOnCorrectPositions()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);

            var checkString = builder.ToString();

            Assert.That(checkString.StartsWith("1"));
            Assert.That(checkString.Contains("2"));
        }

        [Test]
        public void AddNumber_AddMultipleNumbers_OutputStringContainsFirstAndLastInputNumber()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);
            builder.AddNumber(3);

            var checkString = builder.ToString();

            Assert.That(checkString.StartsWith("1"));
            Assert.That(checkString.Contains("3"));
            Assert.That(!checkString.Contains("2"));
        }

        [Test]
        public void Build_CalculationIsNull_ThrowsInvalidOperationException()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);

            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument1IsNull_ThrowsInvalidOperationException()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument2IsNull_ThrowsInvalidOperationException()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObject()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result, Is.InstanceOf<ICalculation>());
        }

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObjectWithCorrectArgs()
        {
            var builder = new ExtendedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result.GetResult(), Is.EqualTo(2));
        }

        [Test]
        public void ToString_CalculationFieldIsNull_ThrowsInvalidOparationException()
        {
            var builder = new ExtendedCalculationBuilder();

            Assert.That(() => builder.ToString(), Throws.InvalidOperationException);
        }

        [Test]
        public void ToString_CalculationAndArgsAreSet_ReturnsCorrectlyFormatedString()
        {
            var builder = new ExtendedCalculationBuilder();
            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);

            var result = builder.ToString();

            Assert.That(result, Is.EqualTo("1 + 2 = 3"));
        }

    }
}

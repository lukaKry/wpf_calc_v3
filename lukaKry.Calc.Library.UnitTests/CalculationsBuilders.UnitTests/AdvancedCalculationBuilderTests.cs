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
    public class AdvancedCalculationBuilderTests
    {
        [Test]
        public void AddCalculation_FirstSumCalculationIsSum_OutputStringContainsPlusSymbol()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);

            var result = builder.ToString();

            Assert.That(result, Does.Contain("+"));
            Assert.That(result[2], Is.EqualTo('+'));
        }


        [Test]
        public void AddCalculation_TwoDifferentCalculations_OutputStringContainsBothSymbols()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);
            builder.AddCalculation(new Multiplication());
            builder.AddNumber(3);

            var result = builder.ToString();

            Assert.That(result, Does.Contain("+"));
            Assert.That(result, Does.Contain("*"));
        }


        [Test]
        [TestCase(CalculationType.Sum, '+')]
        [TestCase(CalculationType.Subtraction, '-')]
        [TestCase(CalculationType.Multiplication, '*')]
        [TestCase(CalculationType.Division, '/')]
        public void AddCalculation_TripleCalculations_OutputStringContainsCorrectCalculationSymbols(CalculationType type, char symbol)
        {
            var builder = new AdvancedCalculationBuilder();
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
        [TestCase(CalculationType.Subtraction, CalculationType.Sum, CalculationType.Multiplication, 11)]
        [TestCase(CalculationType.Subtraction, CalculationType.Sum, CalculationType.Division, -0.25)]
        [TestCase(CalculationType.Sum, CalculationType.Subtraction, CalculationType.Multiplication, -9)]
        [TestCase(CalculationType.Sum, CalculationType.Subtraction, CalculationType.Division, 2.25)]
        [TestCase(CalculationType.Multiplication, CalculationType.Sum, CalculationType.Multiplication, 14)]
        [TestCase(CalculationType.Sum, CalculationType.Multiplication, CalculationType.Sum, 11)]
        public void CheckResult_DifferentCalculationsOrder_CorrectCalculationResult(CalculationType type1,CalculationType type2, CalculationType type3, decimal output)
        {
            var builder = new AdvancedCalculationBuilder();
            var factory = new CalculationsFactoryProvider();

            builder.AddNumber(1);
            builder.AddCalculation(factory[type1].Create());
            builder.AddNumber(2);
            builder.AddCalculation(factory[type2].Create());
            builder.AddNumber(3);
            builder.AddCalculation(factory[type3].Create());
            builder.AddNumber(4);


            var result = builder.Build().GetResult();

            Assert.That(result, Is.EqualTo(output));
        }


        // testy ponizej trzeba dopasowac do tej klasy, poniewaz sa skopiowane z ExtendedCalculationBuilderTests class
        [Test]
        public void AddNumber_AddTwoNumbers_OutputStringContainsAddedNumberOnCorrectPositions()
        {
            var builder = new AdvancedCalculationBuilder();

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
            var builder = new AdvancedCalculationBuilder();

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
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);

            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument1IsNull_ThrowsInvalidOperationException()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_Argument2IsNull_ThrowsInvalidOperationException()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObject()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result, Is.InstanceOf<ICalculation>());
        }

        [Test]
        public void Build_FieldsAreNotNull_ReturnsICalculationObjectWithCorrectArgs()
        {
            var builder = new AdvancedCalculationBuilder();

            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(1);

            var result = builder.Build();

            Assert.That(result.GetResult(), Is.EqualTo(2));
        }

        [Test]
        public void ToString_CalculationFieldIsNull_ThrowsInvalidOparationException()
        {
            var builder = new AdvancedCalculationBuilder();

            Assert.That(() => builder.ToString(), Throws.InvalidOperationException);
        }

        [Test]
        public void ToString_CalculationAndArgsAreSet_ReturnsCorrectlyFormatedString()
        {
            var builder = new AdvancedCalculationBuilder();
            builder.AddNumber(1);
            builder.AddCalculation(new Sum());
            builder.AddNumber(2);

            var result = builder.ToString();

            Assert.That(result, Is.EqualTo("1 + 2 = 3"));
        }
    }
}

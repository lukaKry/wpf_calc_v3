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

        public void AddCalculation_FirstCalculation_OutputStringContainsCorrectCalculationSymbol(CalculationType type, char symbol)
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



    }
}

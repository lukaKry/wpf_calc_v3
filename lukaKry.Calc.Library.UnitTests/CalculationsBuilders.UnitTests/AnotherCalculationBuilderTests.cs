using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using lukaKry.Calc.Library.Logic.CalculationsBuilders;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests.CalculationsBuilders.UnitTests
{
    public class AnotherCalculationBuilderTests
    {
        [Test]
        public void addNum_firstNum()
        {
            // metoda ta bedzie dodawac kolejna liczbe do listy o ile ilosc kalkulacji na drugiej liscie na to pozwala
            // jesli ilosc kalkulacji jest tam niewystarczajaca, to ostatni numer bedzie podmieniony
        }

        [Test]
        public void addNum_anyFurtherNum() { }

        [Test]
        public void addCalc_firstCalc()
        {
            // metoda ta bedzie dodawac kolejna kalkulacje do listy o ile ilosc cyfr na drugiej liscie na to pozwala
            // jesli ilosc liczb jest tam niewystarczajaca, to ostatni typ kalkulacji bedzie jedynie podmnieniony
        }

        [Test]
        public void addCalc_anyFurtherCalc() { }

        [Test]
        public void build_noCompleteDataToCalc() { }

        [Test]
        public void build_completeDataToCalc() { }

        [Test]
        public void toString_correctCAlculation() { }


        [Test]
        public void reset_setEverythingToInitialState() { }

        [Test]
        public void Solve_Simple2plus2_ReturnsFour()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Sum() };
            List<decimal> nums = new() { 2, 2 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Solve_DoubleSum_ReturnsSix()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Sum(), new Sum() };
            List<decimal> nums = new() { 2, 2, 2 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Solve_DifferentPriority_ReturnsTwelve()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Sum(), new Multiplication() };
            List<decimal> nums = new() { 3, 3, 3 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Solve_DifferentPriority_ReturnsTwentyOne()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Sum(), new Multiplication(), new Sum(), new Multiplication() };
            List<decimal> nums = new() { 3, 3, 3, 3, 3 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(21));
        }

        [Test]
        public void Solve_DifferentPriority_ReturnsFifteen()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Sum(), new Multiplication(), new Division(), new Sum(), new Multiplication() };
            List<decimal> nums = new() { 3, 3, 3, 3, 3, 3 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Solve_DifferentPriorityWithPower_ReturnsFiftythree()
        {
            var builder = new AnotherCalculationBuilder();

            List<ISettableCalculation> calcs = new() { new Multiplication(), new Power(), new Subtraction(), new Division() };
            List<decimal> nums = new() { 2, 3, 3, 3, 3 };

            var result = builder.Solve(calcs, nums);

            Assert.That(result, Is.EqualTo(53));
        }
    }
}

﻿using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using lukaKry_Calc_Library.UnitTests.Mocks;
using Moq;
using NUnit.Framework;
using System;

namespace lukaKry_Calc_Library.UnitTests
{
    class CalculatorTests
    {
        private CalculationsFactoryProvider _provider = new();
        private Calculator _calc;
        private SimpleCalculationBuilder _builder = new();

        [SetUp]
        public void SetUp()
        {
            _calc = new Calculator(_builder);
        }

        [Test]
        public void ResetCurrentCalculation_WhenCalled_SetFieldToNull()
        {
            _calc.ResetCurrentCalculation();

            var result = _calc.CurrentCalculation;

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetResult_CurrentCalculationNotNull_ReturnsDecimalValue()
        {
            var builder = new Mock<ICalculationBuilder>();
            builder.Setup(b => b.Build()).Returns(new Sum()
            {
                Arg1 = new Number(1),
                Arg2 = new Number(1)
            });

            _calc = new Calculator(builder.Object);

            var result = _calc.GetResult();

            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void GetResult_CurrentCalculationIsNull_ThrowException()
        {
            _calc.ResetCurrentCalculation();

            Assert.That(() => _calc.GetResult(), Throws.InvalidOperationException);
        }
    }
}

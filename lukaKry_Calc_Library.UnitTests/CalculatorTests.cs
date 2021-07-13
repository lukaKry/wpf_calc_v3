using lukaKry_Calc_Library.Logic;
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
        private IRegistry _registry = new FakeRegistry();
        private Calculator _calc;
        private SimpleCalculationBuilder _builder = new();

        [SetUp]
        public void SetUp()
        {
            _calc = new Calculator(_registry, _builder);
        }


        [Test]
        public void SaveCalculation_WhenCalled_CallAddItemOnRegistryObject()
        {
            var registry = new Mock<IRegistry>();
            _calc = new Calculator(registry.Object);
            ICalculation calculation = new Sum();

            _calc.SaveCalculation(calculation);

            registry.Verify(r => r.AddItem(calculation));
        }

        [Test]
        public void RestoreCalculation_WhenCalled_GetPreviouslySavedCalculation()
        {
            var registry = new RegistrySimple();
            _calc = new Calculator(registry);
            ICalculation calculation = new Sum();

            _calc.SaveCalculation(calculation);

            var result = _calc.RestoreCalculation();

            Assert.That(result, Is.EqualTo(calculation));
        }

        [Test]
        public void RestoreCalculation_NoCalculationToRestore_ThrowInvalidOperationException()
        {
            var registry = new Mock<IRegistry>();
            registry.Setup(r => r.GetLastItem()).Throws(new InvalidOperationException());
            _calc = new Calculator(registry.Object);

            Assert.That(() => _calc.RestoreCalculation(), Throws.InvalidOperationException);
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

            _calc = new Calculator(new FakeRegistry(), builder.Object);

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

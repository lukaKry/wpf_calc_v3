using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using lukaKry_Calc_Library.UnitTests.Mocks;
using NUnit.Framework;

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
        public void AddCalculationToRegistry_WhenCalled_WhatToExpect()
        {
           // jak to przetestowac ? 
           // pole jest prywatne, jak sprawdzic czy uleglo zmianie ? 
        }


        [Test]
        public void EditCalculationAddNumber_WhenCurrentCalculationIsNull_AssignNumber()
        {
            // jak to przetestowac ?
        }


        [Test]
        public void EditCalculationAddNumber_WhenCurrentCalculationIsNumber_ChangeNumber()
        {
            // jak to przetestowac ?
        }

        [Test]
        public void EditCalculationAddNumber_WhenCurrentCalculationIsNotNumberAndNull__AddNumberAsArg2()
        {

        }


        [Test]
        public void ResetCurrentCalculation_WhenCalled_SetFieldToNull()
        {
            // jak to przetestowac ?
        }



        [Test]
        public void GetLastCalculationFromRegistry_WhenRegistryNotEmpty_ReturnsICalculationItem() 
        {
            _registry.AddItemToRegistry(new Number(1));

            ICalculation result = _calc.GetLastCalculationFromRegistry();

            Assert.That(result, Is.InstanceOf<ICalculation>());
            // taki test ma sens?   
        }


        [Test]
        public void GetLastCalculationFromRegistry_WhenRegistryIsEmpty_ThrowsException()
        {
            Assert.That(() => _calc.GetLastCalculationFromRegistry() ,Throws.InvalidOperationException);
        }


        [Test]
        public void GetResult_CurrentCalculationNotNull_ReturnsDecimalValue()
        {
            //_calc.EditCalculationAddNumber(1);

            var result = _calc.GetResult();

            Assert.That(result, Is.TypeOf<decimal>());
        }


        [Test]
        public void GetResutl_CurrentCalculationIsNull_ThrowException()
        {
            Assert.That(() => _calc.GetResult(), Throws.InvalidOperationException);
        }
    }
}

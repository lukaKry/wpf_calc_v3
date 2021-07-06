using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry_Calc_Library.UnitTests
{
    class CalculatorTests
    {
        private IRegistry _registry;
        private Calculator _calc;

        [SetUp]
        public void SetUp()
        {
            _registry = new RegistrySimple();
            _calc = new Calculator(_registry);
        }


        [Test]
        public void AddCalculationToRegistry_WhenCalled_WhatToExpect()
        {
           // jak to przetestowac ? 
        }


        [Test]
        public void EditCalculationAddNumber_WhenCurrentCalculationIsNull_AssignNumber()
        {
            // jak to przetestowac ?
        }


        [Test]
        public void EditCalculationAddNumber_WhenCurrentCalculationIsNotNull_AssignNumber()
        {
            // jak to przetestowac ?
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
            _calc.EditCalculationAddNumber(1);

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

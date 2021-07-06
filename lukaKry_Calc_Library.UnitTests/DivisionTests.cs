using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;
using System;

namespace lukaKry_Calc_Library.UnitTests
{
    class DivisionTests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Test cases:
        
            2 / 2 = 1
            2 / 2 / 2 = 0.5
            -2 * (-2) * (-2) = -0.5
            
            2 / 0 = throws exception

            no args set = 0
            
        */

        [Test]
        [TestCase(2, 2, 1)]
        public void GetResult_WithBothArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal outcome)
        {
            Division division = new()
            {
                Arg1 = new Number(arg1),
                Arg2 = new Number(arg2)
            };

            var result = division.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }


        [Test]
        [TestCase(2, 2, 2, 0.5)]
        [TestCase(-2, -2, -2, -0.5)]
        public void GetResult_WithAllArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal arg3, decimal outcome)
        {
            // uwaga przy tworzeniu nowych kalkulacji
            // stworzenie np. zagnieżdżonych obiektów typu Sum i przypisywanie liczb ( typ Number ) do pierwszego argumentu 
            // ( Arg1 ) spowoduje rozwiązywanie równania od prawej do lewej 
            // natomiast przypisanie pierwszego argumentu na pozycji drugiej ( Arg2 ) będzie skutkowało rozwiązywaniem od lewej do prawej



            Division division = new()
            {
                Arg2 = new Number(arg1),
                Arg1 = new Division()
                {
                    Arg2 = new Number(arg2),
                    Arg1 = new Number(arg3)
                }
            };

            var result = division.GetResult();

            Assert.That(result, Is.EqualTo(outcome));

        }


        [Test]
        [TestCase(2, 0)]
        public void GetResult_DivisorIsZero_ThrowException(decimal arg1, decimal arg2)
        {

            Assert.That( () =>
            {
                Division division = new()
                {
                    Arg1 = new Number(arg1),
                    Arg2 = new Number(arg2)
                };
            },
            Throws.Exception.TypeOf<DivideByZeroException>() );
        }


        [Test]
        public void GetResult_DivisorIsCalculationWhichResultsInZero_ThrowException()
        {

            Assert.That(() =>
            {
                Division division = new()
                {
                    Arg1 = new Number(2),
                    Arg2 = new Subtraction()
                    {
                        Arg1 = new Number(2),
                        Arg2 = new Number(2)
                    }
                };

                var result = division.GetResult();
            },
            Throws.Exception.TypeOf<DivideByZeroException>());
        }


        [Test]
        public void GetResult_NoArgsSet_GetResultsFromDefaultArgsValues()
        {
            Division division= new();
            var result = division.GetResult();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

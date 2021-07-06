﻿using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry_Calc_Library.UnitTests
{
    class MultiplicationTests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Test cases:
        
            2 * 2 = 4
            2 * 2 * 2 = 8
            -2 * (-2) * (-2) = -8
            
            no args set = 0
        */

        [Test]
        [TestCase(2,2,4)]
        public void GetResult_WithBothArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal outcome)
        {
            Multiplication multiplication = new()
            {
                Arg1 = new Number(arg1),
                Arg2 = new Number(arg2)
            };

            var result = multiplication.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }


        [Test]
        [TestCase(2, 2, 2, 8)]
        [TestCase(-2, -2, -2, -8)]
        public void GetResult_WithAllArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal arg3, decimal outcome)
        {
            // uwaga przy tworzeniu nowych kalkulacji
            // stworzenie np. zagnieżdżonych obiektów typu Sum i przypisywanie liczb ( typ Number ) do pierwszego argumentu 
            // ( Arg1 ) spowoduje rozwiązywanie równania od prawej do lewej 
            // natomiast przypisanie pierwszego argumentu na pozycji drugiej ( Arg2 ) będzie skutkowało rozwiązywaniem od lewej do prawej



            Multiplication multiplication = new()
            {
                Arg2 = new Number(arg1),
                Arg1 = new Multiplication()
                {
                    Arg2 = new Number(arg2),
                    Arg1 = new Number(arg3)
                }
            };

            var result = multiplication.GetResult();

            Assert.That(result, Is.EqualTo(outcome));

        }


        [Test]
        public void GetResult_NoArgsSet_GetResultsFromDefaultArgsValues()
        {
            Multiplication multiplication= new();
            var result = multiplication.GetResult();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

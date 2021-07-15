﻿using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests
{
    class SumTests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Test cases:
        
            2 + 2 = 4
            2 + 2 + 2 = 6

            no args set = 0

        */


        [Test]
        [TestCase(2, 2, 4)]
        public void GetResult_WithBothArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal outcome)
        {
            Sum sum = new()
            {
                Arg1 = new Number(arg1),
                Arg2 = new Number(arg2)
            };

            var result = sum.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }


        [Test]
        [TestCase(2, 2, 2, 6)]
        public void GetResult_WithAllArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal arg3, decimal outcome)
        {
            Sum sum = new() 
            {
                Arg1 = new Number(arg1),
                Arg2 = new Sum() 
                {
                    Arg1 = new Number(arg2),
                    Arg2 = new Number(arg3)
                }
            };

            var result = sum.GetResult();

            Assert.That(result, Is.EqualTo(outcome));

        }


        [Test]
        public void GetResult_NoArgsSet_GetResultsFromDefaultArgsValues()
        {
            Sum sum = new();
            var result = sum.GetResult();
            Assert.That(result, Is.EqualTo(0));

            //Assert.That(() => sum.GetResult(), Throws.Exception.TypeOf<NullReferenceException>());
        }

    }
}

using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;
    
namespace lukaKry_Calc_Library.UnitTests
{
    class SumTests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Test cases:
        
            2+2=4
            2+2+2=6
            

        */


        [Test]
        [TestCase(2, 2, 4)]
        public void Calculate_WithSetBothArgs_CorrectResult(decimal arg1, decimal arg2, decimal outcome)
        {
            Number num1 = new(arg1);

            Sum sum = new();
            sum.SetArg1(num1);

            Number num2 = new(arg2);

            // pressed = sign button
            sum.SetArg2(num2);
            var result = sum.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }


        [Test]
        [TestCase(2, 2, 2, 6)]
        public void Calculate_WithSetBothArgs_CorrectResult(decimal arg1, decimal arg2, decimal arg3, decimal outcome)
        {
            // pressed number 2 button
            Number num1 = new(arg1);

            // pressed + sign button
            Sum sum1 = new();
            sum1.SetArg1(num1);

            // pressed number 2 button
            Number num2 = new(arg2);

            // pressed + sing button
            Sum sum2 = new();
            sum2.SetArg1(num2);
            sum1.SetArg2(sum2);

            // pressed number 2 button
            Number num3 = new(arg3);

            // pressed = sign button
            sum2.SetArg2(num3);
            var result = sum1.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }

    }
}

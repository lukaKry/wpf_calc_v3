using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
using NUnit.Framework;


namespace lukaKry.Calc.Library.UnitTests
{
    class SubtractionTests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Test cases:
        
            2 - 2 = 0
            2 - 2 - 2 = -2
            -2 - (-2) - (-2) = 2

            no args set = 0

        */

        [Test]
        [TestCase(0,2,-2)]
        public void GetResult_WithBothArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal outcome)
        {
            Subtraction subtraction = new()
            {
                Arg1 = new Number(arg1),
                Arg2 = new Number(arg2)
            };

            var result = subtraction.GetResult();

            Assert.That(result, Is.EqualTo(outcome));
        }


        [Test]
        [TestCase(2, 2, 2, -2)]
        [TestCase(-2, -2, -2, 2)]
        public void GetResult_WithAllArgsSet_CorrectResult(decimal arg1, decimal arg2, decimal arg3, decimal outcome)
        {
            // uwaga przy tworzeniu nowych kalkulacji
            // stworzenie np. zagnieżdżonych obiektów typu Sum i przypisywanie liczb ( typ Number ) do pierwszego argumentu 
            // ( Arg1 ) spowoduje rozwiązywanie równania od prawej do lewej 
            // natomiast przypisanie pierwszego argumentu na pozycji drugiej ( Arg2 ) będzie skutkowało rozwiązywaniem od lewej do prawej



            Subtraction subtraction = new()
            {
                Arg2 = new Number(arg1),
                Arg1 = new Subtraction()
                {
                    Arg2 = new Number(arg2),
                    Arg1 = new Number(arg3)
                }
            };

            var result = subtraction.GetResult();

            Assert.That(result, Is.EqualTo(outcome));

        }


        [Test]
        public void GetResult_NoArgsSet_GetResultsFromDefaultArgsValues()
        {
            Subtraction subtraction = new();
            var result = subtraction.GetResult();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

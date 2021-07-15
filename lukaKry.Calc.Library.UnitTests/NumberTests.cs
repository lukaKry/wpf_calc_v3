using lukaKry.Calc.Library.Logic;
using NUnit.Framework;

namespace lukaKry.Calc.Library.UnitTests
{
    class NumberTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetResult__CorrectResult()
        {
            Number number = new(1);

            var result = number.GetResult();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}


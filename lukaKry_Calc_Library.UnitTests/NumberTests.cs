using lukaKry_Calc_Library.Logic;
using NUnit.Framework;

namespace lukaKry_Calc_Library.UnitTests
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


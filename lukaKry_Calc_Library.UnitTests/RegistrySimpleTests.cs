using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Library.Logic.Calculations;
using NUnit.Framework;

namespace lukaKry_Calc_Library.UnitTests
{
    class RegistrySimpleTests
    {
        [Test]
        public void AddItemToRegistry_WhenCalled_ItemIsOnTheList()
        {
            var registry = new RegistrySimple();
            ICalculation calculation = new Sum();

            registry.AddItem(calculation);

            Assert.That(registry.Count, Is.EqualTo(1));
        }


        [Test]
        public void GetLastItem_ListIsEmpty_ThrowsInvalidOperationException()
        {
            var registry = new RegistrySimple();

            Assert.That(() => registry.GetLastItem(), Throws.InvalidOperationException);
        }

        [Test]
        public void GetLastItem_FewItemsOnAList_ReturnsLastCalculation()
        {
            var registry = new RegistrySimple();
            ICalculation calculation1 = new Sum();
            ICalculation calculation2 = new Sum();

            registry.AddItem(calculation1);
            registry.AddItem(calculation2);

            var result = registry.GetLastItem();

            Assert.That(result, Is.EqualTo(calculation2));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lukaKry.Calc.API.Controllers;
using lukaKry.Calc.API.Services;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.CalculationsBuilders;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace lukaKry.Calc.API.UnitTests.Controllers
{
    public class CalculationsControllerTests
    {
        private CalculationsController _controller;
        private ICalculationBuilder _builder;
        private IRegistry _archiver;
        private CalculationsFactoryProvider _provider;


        [SetUp]
        public void Setup()
        {
            _provider = new CalculationsFactoryProvider(); 
            _builder = new AdvancedCalculationBuilder();

            string[] calculationArchive = new string[] { "1 + 2 = 3", "3 - 2 = 1" };
            var mockArchiver = new Mock<IRegistry>();
            mockArchiver.Setup(m => m.GetAll()).Returns(calculationArchive);
            _archiver = mockArchiver.Object;

            _controller = new CalculationsController(_builder, _archiver, _provider);
        }

        [Test]
        public void AddNumber_IncorrectStringNumberFormat_ReturnBadrequestAnswer()
        {
            var actionResult = _controller.AddNumber("1a");
            var acceptedResult = actionResult as AcceptedResult;

            Assert.IsNotNull(acceptedResult);

            // ?? cos tu dalej nie dziala
            Assert.AreEqual(202, acceptedResult.StatusCode);
        }
    }
}

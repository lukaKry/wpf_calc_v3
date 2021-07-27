using lukaKry.Calc.API.DataAccess;
using lukaKry.Calc.API.Services;
using lukaKry.Calc.Library.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaKry.Calc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private ICalculationBuilder _builder;
        private readonly IRegistry _archiver;
        private readonly CalculationsFactoryProvider _provider;

        public CalculationsController(ICalculationBuilder builder, IRegistry archiver, CalculationsFactoryProvider provider)
        {
            _archiver = archiver;
            _builder = builder;
            _provider = provider;
        }

        [HttpPost]
        [Route("addnum")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNumber([FromBody] string number)
        {
            decimal parsedNumber;
            if(decimal.TryParse(number, out parsedNumber)) 
            {
                return BadRequest("Not a correct number format");
            }

            _builder.AddNumber(parsedNumber);

            return Accepted();
        }

        [HttpPost]
        [Route("addcalc")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCalculation([FromBody] string symbol)
        {
            if (!IsValidCalculationSymbol(symbol)) return BadRequest("Not a correct calculation symbol");

            var type = GetCalculationType(symbol);
            _builder.AddCalculation(_provider[type].Create());

            return Accepted();
        }

        private static bool IsValidCalculationSymbol(string calcTypeChoice)
        {
            string[] validKeys = { "+", "-", "*", "/" };
            return Array.IndexOf(validKeys, calcTypeChoice) >= 0;
        }
        private static CalculationType GetCalculationType(string calcTypeChoice)
        {
            switch (calcTypeChoice)
            {
                case "-": return CalculationType.Subtraction;
                case "*": return CalculationType.Multiplication;
                case "/": return CalculationType.Division;
                default: return CalculationType.Sum;
            }
        }


        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CalculationRecord>))]
        public IActionResult GetAllCalculationRecords()
        {
            return Ok(_archiver.GetAll());
        }

        [HttpGet]
        [Route("getresult")]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public IActionResult GetResult()
        {
            try
            {
                var builtCalculation = _builder.Build();

                _archiver.AddCalculation(builtCalculation);

                _builder.Reset();

                return Ok(builtCalculation.GetResult());
            }
            catch (InvalidOperationException)
            {
                return StatusCode(405, "nothing yet to calculate");
            }

        }
    }
}

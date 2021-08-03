﻿using lukaKry.Calc.API.DataAccess;
using lukaKry.Calc.API.Services;
using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.Calculations;
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
        [ProducesResponseType(StatusCodes.Status202Accepted)]       // korzystanie z atrybutów jest szczególnie przydatne przy automatycznym generowaniu openAPI swagger specification 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]     // tutaj widać, że mam przewidziane dwa typy zwrotu, więc IActionResult jest dobrym wyborem
        public IActionResult AddNumber([FromBody] string number)    // IActionResult jest odpowiednim typem w momencie, gdy nasza metoda moze zwrócić różne typy odpowiedzi
        {
            if(!decimal.TryParse(number, out decimal parsedNumber)) 
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

            var calcType = GetCalculationType(symbol);
            _builder.AddCalculation(calcType);

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
        [Route("getlast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLastCalculation()
        {
            // zdecydowanie lepiej jakby ta metoda zwracala tylko to, co potrzebne jest do wyswietlenia
            // czyli coś typu { "equation" : "1+1", "result": 2 }

            var lastCalc = await _archiver.GetLastCalculation();
            return Ok(MapResult(lastCalc));
        }

        private static MappedResult MapResult(Equation clc)
        {
            var result = new MappedResult()
            {
                Result = clc.GetResult(),
                Equation = clc.ToString()
            };

            return result;
        }

        public class MappedResult
        {
            public decimal Result { get; set; }
            public string Equation { get; set; }
        }


        [HttpGet]
        [Route("getresult")]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<IActionResult> GetResult()
        {
            try
            {
                var builtCalculation = _builder.Build();

                await _archiver.AddCalculation(builtCalculation);

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

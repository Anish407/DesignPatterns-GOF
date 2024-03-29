﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridge;
using Bridge.Enum;
using Bridge.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Gof.Web.Controllers
{
    [ApiController]
    [Route("Weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Func<int, IShape> shapeFunc)
        {
            _logger = logger;
            ShapeFunc = shapeFunc;
        }

        [HttpGet("DrawShape/{shapeId:int:min(1):max(2)}/UsingType/{drawTypeId:int:min(1):max(3)}")]
        public IActionResult GetData(int shapeId, int drawTypeId)
        {
            return Ok(ShapeFunc(shapeId).Draw((DrawApiType)drawTypeId));
        }

        public IRectangle Rectangle { get; }
        public Func<int, IShape> ShapeFunc { get; }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

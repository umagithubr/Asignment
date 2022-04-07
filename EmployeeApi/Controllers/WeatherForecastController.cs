using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHostEnvironment _hostEnvironment;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        
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
        [HttpPost]
        public ActionResult<Employee> CreateEmployee()
        {
            try
            {
                string jsondata = new JavaScriptSerializer().Serialize(new Employee());
                string path = _hostEnvironment.ContentRootPath;
                // Write that JSON to txt file,  
                var myUniqueFileName = $@"{DateTime.Now.Ticks}.json";
                System.IO.File.WriteAllText(path + "\\wwwroot\\" + myUniqueFileName, jsondata);

                return StatusCode(StatusCodes.Status200OK,
                "Employee record has create");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

    }
}

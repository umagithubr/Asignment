using Microsoft.AspNetCore.Cors;
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
    [EnableCors("mypolicy")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IHostEnvironment _hostEnvironment;
        public EmployeeController(ILogger<EmployeeController> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                //var employee= "{'Firstname':'umapathi','Lastname':'rayapati'}";
                string jsondata = new JavaScriptSerializer().Serialize(employee);
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

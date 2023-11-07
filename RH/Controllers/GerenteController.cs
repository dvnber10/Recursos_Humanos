using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RH.Controllers
{
    [Route("[controller]")]
    public class GerenteController : Controller
    {
        private readonly ILogger<GerenteController> _logger;

        public GerenteController(ILogger<GerenteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Usuario"]= "Gerente";
            return View();
        }
    }
}
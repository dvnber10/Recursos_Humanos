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
    public class GestorController : Controller
    {
        private readonly ILogger<GestorController> _logger;

        public GestorController(ILogger<GestorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Usuario"]= "Gestor de Recursos";
            return View();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Models;

namespace RH.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private RecursosHumanosContext _context;
        public AdminController(ILogger<AdminController> logger, RecursosHumanosContext contexto)
        {
            _logger = logger;
            _context = contexto;
        }
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {

            ViewData["Usuario"] = "Administrador";

            return View(_context.Usuarios.ToList());
        }
        //[Route("/Grafico")]
        //public IActionResult Grafico()
        //{
        //    var datos = _context.Nominas.ToList();
        //    var chartData = datos.Select(dp => new
        //    {
        //        x = dp.CanHoras,
        //        y = dp.IdUser
        //    }).ToList();
        //    return View(datos);
       // }
    }
}
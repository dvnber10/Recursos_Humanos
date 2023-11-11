using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Models;
using RH.Logica;
namespace RH.Controllers
{
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly RecursosHumanosContext _context;

        public EmpleadoController(ILogger<EmpleadoController> logger, RecursosHumanosContext contexto)
        {
            _logger = logger;
            _context= contexto;
        }

        [Authorize (Roles ="3")]
        public IActionResult Index()
        {
            ViewData["Usuario"]= "Empleado";
            string nombre = User.Identity.Name;
            var user =_context.Usuarios.Where(u => u.Contraseña == nombre ).Where(u => u.IdRol== 3).FirstOrDefault();
            var nom = _context.Nominas.Where(u=>u.IdUser == user.IdUsuario).FirstOrDefault();
            CalcularNomina calcular = new CalcularNomina();
            string sueldo = calcular.calcular(nom.CanHoras,nom.Aumento, nom.Descuento).ToString();
            ViewData["Sueldo"]= sueldo;
            ViewData["Nombre"]= user.Nombre;
            ViewData["Cargo"]= user.Cargo;
            ViewData["Afiliuacion"]= user.Afiliacions;
            ViewData["CanH"]= nom.CanHoras ;
            ViewData["Aumento"]= nom.Aumento;
            ViewData["Descuento"]= nom.Descuento;

            return View();
        }
        [Route("/GraficoEmpleado")]
        [Authorize(Roles ="3")]
        public IActionResult Grafico(){
           ViewData["Usuario"]= "Empleado";
           string nombre = User.Identity.Name;
            var user =_context.Usuarios.Where(u => u.Contraseña == nombre ).Where(u => u.IdRol== 3).FirstOrDefault();
            var nom = _context.Nominas.Where(u=>u.IdUser == user.IdUsuario).FirstOrDefault();
            Console.WriteLine(nom.CanHoras);
            return View(nom);
        }
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RH.Models;

namespace RH.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RecursosHumanosContext _context;

    public HomeController(ILogger<HomeController> logger, RecursosHumanosContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Registro(){
        return View();
    }
    [HttpPost]
    public IActionResult Registro([FromForm] Usuario usuario){
        var pass = HttpContext.Request.Form["password"];
        var CPass = HttpContext.Request.Form["confpassword"];
        if (pass==CPass)
        {
            var user = new Usuario{
                Nombre= usuario.Nombre,
                Correo = usuario.Correo,
                Documento = usuario.Documento,
                Direccion = " ",
                Telefono = usuario.Telefono,
                Cargo = "Aspirante",
                Contraseña = pass,
                IdRol = 1,
                
            };
            usuario.SesionActiva =true;
            _context.Usuarios.Add(user);
            var estdo = new Estado{
                Estado1 = "En espera"
            };
            
            _context.Estados.Add(estdo);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }else
        {
            return Registro();
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

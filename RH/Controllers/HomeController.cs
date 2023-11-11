using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RH.Models;
using RH.Sevices;

namespace RH.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RecursosHumanosContext _context;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger, RecursosHumanosContext context, IConfiguration config)
    {
        _logger = logger;
        _context = context;
        _config = config;
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
    public async Task<IActionResult> Registro([FromForm] Usuario usuario){
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
                IdRol = 2,
                Idcontratacion= 2,
                
            };
            var emailService = new EmailServices(_config);
            var emailRequest = new EmailDTO
            {
                Para = usuario.Correo,
                Asunto = "Cuenta Agregada al sistema",
                Contenido = "La cuenta del usuario "+usuario.Nombre+" ha sido creada correctamente",
            };
             emailService.SendEmail(emailRequest);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }else{
            return View();
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

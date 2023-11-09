using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Models;

namespace RH.Controllers
{
    public class AspiranteController : Controller
    {
        private readonly ILogger<AspiranteController> _logger;
        private readonly RecursosHumanosContext _context;

        public AspiranteController(ILogger<AspiranteController> logger, RecursosHumanosContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Salir(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Cuenta");
        }   
        [Authorize (Roles ="2")]
        public  IActionResult Index()
        {
            ViewData["Usuario"]="Aspirante";
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Index(IFormFile file)
        {
          if (file != null && file.Length > 0)
          {
            using (var memoryStream = new MemoryStream()){
                await file.CopyToAsync(memoryStream);
                byte[] datosImagen = memoryStream.ToArray();
                var user = new Usuario{
                    Curriculum = datosImagen,
                };
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            }
          }
          ViewData["datos"]= "Curriculum Guardado Correctamente";
        ViewData["Usuario"]="Aspirante";
        return RedirectToAction("Index","Aspirante");
        }
    }
}
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
    }
}
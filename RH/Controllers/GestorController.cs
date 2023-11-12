using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using RH.Models;
using RH.Sevices;


namespace RH.Controllers
{
    [Route("[controller]")]
    public class GestorController : Controller
    {
        private readonly ILogger<GestorController> _logger;
        private readonly RecursosHumanosContext _context;
        private readonly IConfiguration _config;

        public GestorController(ILogger<GestorController> logger, RecursosHumanosContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _config = configuration;
        }
        [Authorize(Roles = "5")]
        public IActionResult Index()
        {
            ViewData["Usuario"] = "Gestor de Recursos";
            var lista = _context.Usuarios.Where(u => u.IdRol == 2).ToList();
            return View(lista);
        }
        [Route("/contratar")]
        [Authorize(Roles = "5")]
        public async Task<IActionResult> Contratar(int id)
        {
            var usuario = _context.Usuarios.Where(u => u.IdUsuario == id).FirstOrDefault();
            try
            {

                usuario.IdRol = 3;
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                var emailService = new EmailServices(_config);
                var emailRequest = new EmailDTO
                {
                    Para = usuario.Correo,
                    Asunto = "Cuenta Agregada al sistema",
                    Contenido = "El Usuario " + usuario.Nombre + " Ha sido contratado bienvenido a nuestro servicio",
                };
                emailService.SendEmail(emailRequest);
            }
            catch (DbUpdateConcurrencyException e)
            {
                ViewBag.Message = e + " Error al actualizar la base de datos";
            }
            return RedirectToAction("Index", "Gestor");
        }
        [Route("/DetallesGestor")]
        [Authorize(Roles = "5")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdcontratacionNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Usuario"] = "Gerente";
            return View(usuario);
        }
        [Route("/EditarGestor")]
        [Authorize(Roles = "5")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRol);
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion", usuario.Idcontratacion);
            ViewData["Usuario"] = "Gerente";
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/EditarGestor")]
        [Authorize(Roles = "5")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Usuario usuario)
        {
            try
            {

                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.IdUsuario))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRol);
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion", usuario.Idcontratacion);
            ViewData["Usuario"] = "Gerente";
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        [Route("/BorrarGestor")]
        [Authorize(Roles = "5")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdcontratacionNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Usuario"] = "Gerente";
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [Route("/BorrarCGestor")]
        [Authorize(Roles = "5")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'RecursosHumanosContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
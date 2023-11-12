using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RH.Models;
using System.IO;

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
        public async Task<ActionResult> Index()
        {

            ViewData["Usuario"] = "Administrador";
            var recursosHumanosContext = _context.Usuarios.Include(u => u.IdRolNavigation).Include(u => u.IdcontratacionNavigation);
            return View(await recursosHumanosContext.ToListAsync());
        }
        [Route("/Grafico")]
        [Authorize(Roles = "1")]
        public IActionResult Grafico()
        {
            try
            {
                var dataPoints = _context.Nominas.ToList();
                var chartData = dataPoints.Select(dp => new
                {
                    x = dp.IdNomina,
                    y = dp.CanHoras
                }).ToList();
                ViewData["Usuario"] = "Administrador";
                return View(chartData);
            }
            catch (System.Exception e)
            {

                ViewBag.Error(e);
            }
            return RedirectToAction("Index", "Admin");
        }
        [Route("/Detalles")]
        [Authorize(Roles = "1")]
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
            ViewData["Usuario"] = "Administrador";
            return View(usuario);
        }

        // GET: Usuarios/Create
        [Route("/Crear")]
        [Authorize(Roles = "1")]
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol");
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion");
            ViewData["Usuario"] = "Administrador";
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/Crear")]
        [Authorize(Roles = "1")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Correo,Documento,Direccion,Telefono,Cargo,Contrase�a,Idcontratacion,IdRol,Curriculum")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRol);
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion", usuario.Idcontratacion);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Route("/Editar")]
        [Authorize(Roles = "1")]
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
            ViewData["Usuario"] = "Administrador";
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/Editar")]
        [Authorize(Roles = "1")]
        
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
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        [Route("/Borrar")]
        [Authorize(Roles = "1")]
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
            ViewData["Usuario"] = "Administrador";
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [Route("/BorrarC")]
        [Authorize(Roles = "1")]
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
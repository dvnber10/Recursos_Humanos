using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RH.Models;

namespace RH.Controllers
{
    [Route("[controller]")]
    public class GerenteController : Controller
    {
        private readonly ILogger<GerenteController> _logger;
        private readonly RecursosHumanosContext _context;
        public GerenteController(ILogger<GerenteController> logger,RecursosHumanosContext contexto)
        {
            _logger = logger;
            _context = contexto;
        }
        [Authorize(Roles = "4")]
        public async Task<IActionResult> Index()
        {
            ViewData["Usuario"] = "Gerente";
            var recursosHumanosContext = _context.Usuarios.Include(u => u.IdRolNavigation).Include(u => u.IdcontratacionNavigation);
            return View(await recursosHumanosContext.ToListAsync());
        }
        [Route("/DetallesG")]
        [Authorize(Roles = "4")]
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

        // GET: Usuarios/Create
        [Route("/CrearG")]
        [Authorize(Roles = "4")]
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol");
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion");
            ViewData["Usuario"] = "Gerente";
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/CrearG")]
        [Authorize(Roles = "4")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Correo,Documento,Direccion,Telefono,Cargo,Contraseña,Idcontratacion,IdRol,Curriculum")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRol);
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion", usuario.Idcontratacion);
            ViewData["Usuario"] = "Gerente";
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Route("/EditarG")]
        [Authorize(Roles = "4")]
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
        [Route("/EditarG")]
        [Authorize(Roles = "4")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Correo,Documento,Direccion,Telefono,Cargo,Contraseña,Idcontratacion,IdRol,Curriculum")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRol);
            ViewData["Idcontratacion"] = new SelectList(_context.Contratacions, "IdContratacion", "IdContratacion", usuario.Idcontratacion);
            ViewData["Usuario"] = "Gerente";
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Route("/BorrarG")]
        [Authorize(Roles = "4")]
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
        [Route("/BorrarCG")]
        [Authorize(Roles = "4")]
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
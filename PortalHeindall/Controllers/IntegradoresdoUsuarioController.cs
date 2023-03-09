using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalHeindall.Data;
using PortalHeindall.Models;

namespace AppHeindall.Controllers
{
    public class IntegradoresdoUsuarioController : Controller
    {
        private readonly GrupoContext _context;

        public IntegradoresdoUsuarioController(GrupoContext context)
        {
            _context = context;
        }

        // GET: IntegradoresdoUsuario
        public async Task<IActionResult> Index()
        {
            var grupoContext = _context.IntegradoresdoUsuario.Include(i => i.Integrador).Include(i => i.Usuario);
            return View(await grupoContext.ToListAsync());
        }

        // GET: IntegradoresdoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IntegradoresdoUsuario == null)
            {
                return NotFound();
            }

            var integradordoUsuario = await _context.IntegradoresdoUsuario
                .Include(i => i.Integrador)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integradordoUsuario == null)
            {
                return NotFound();
            }

            return View(integradordoUsuario);
        }

        // GET: IntegradoresdoUsuario/Create
        public IActionResult Create()
        {
            ViewData["IntegradorId"] = new SelectList(_context.Integradores, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: IntegradoresdoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,IntegradorId")] IntegradordoUsuario integradordoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(integradordoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IntegradorId"] = new SelectList(_context.Integradores, "Id", "Id", integradordoUsuario.IntegradorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", integradordoUsuario.UsuarioId);
            return View(integradordoUsuario);
        }

        // GET: IntegradoresdoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IntegradoresdoUsuario == null)
            {
                return NotFound();
            }

            var integradordoUsuario = await _context.IntegradoresdoUsuario.FindAsync(id);
            if (integradordoUsuario == null)
            {
                return NotFound();
            }
            ViewData["IntegradorId"] = new SelectList(_context.Integradores, "Id", "Id", integradordoUsuario.IntegradorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", integradordoUsuario.UsuarioId);
            return View(integradordoUsuario);
        }

        // POST: IntegradoresdoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,IntegradorId")] IntegradordoUsuario integradordoUsuario)
        {
            if (id != integradordoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(integradordoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegradordoUsuarioExists(integradordoUsuario.Id))
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
            ViewData["IntegradorId"] = new SelectList(_context.Integradores, "Id", "Id", integradordoUsuario.IntegradorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", integradordoUsuario.UsuarioId);
            return View(integradordoUsuario);
        }

        // GET: IntegradoresdoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IntegradoresdoUsuario == null)
            {
                return NotFound();
            }

            var integradordoUsuario = await _context.IntegradoresdoUsuario
                .Include(i => i.Integrador)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integradordoUsuario == null)
            {
                return NotFound();
            }

            return View(integradordoUsuario);
        }

        // POST: IntegradoresdoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IntegradoresdoUsuario == null)
            {
                return Problem("Entity set 'GrupoContext.IntegradoresdoUsuario'  is null.");
            }
            var integradordoUsuario = await _context.IntegradoresdoUsuario.FindAsync(id);
            if (integradordoUsuario != null)
            {
                _context.IntegradoresdoUsuario.Remove(integradordoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegradordoUsuarioExists(int id)
        {
          return _context.IntegradoresdoUsuario.Any(e => e.Id == id);
        }
    }
}

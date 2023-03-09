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
    public class IntegradoresController : Controller
    {
        private readonly GrupoContext _context;

        public IntegradoresController(GrupoContext context)
        {
            _context = context;
        }

        // GET: Integradores
        public async Task<IActionResult> Index()
        {
            var grupoContext = _context.Integradores.Include(i => i.Grupo);
            return View(await grupoContext.ToListAsync());
        }

        // GET: Integradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Integradores == null)
            {
                return NotFound();
            }

            var integrador = await _context.Integradores
                .Include(i => i.Grupo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integrador == null)
            {
                return NotFound();
            }

            return View(integrador);
        }

        // GET: Integradores/Create
        public IActionResult Create()
        {
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id");
            return View();
        }

        // POST: Integradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IntegradorId,IntegradorNome,GrupoUser,GrupoPassword,GrupoPort,PublicKey,PrivateKey,GrupoId")] Integrador integrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(integrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", integrador.GrupoId);
            return View(integrador);
        }

        // GET: Integradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Integradores == null)
            {
                return NotFound();
            }

            var integrador = await _context.Integradores.FindAsync(id);
            if (integrador == null)
            {
                return NotFound();
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", integrador.GrupoId);
            return View(integrador);
        }

        // POST: Integradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IntegradorId,IntegradorNome,GrupoUser,GrupoPassword,GrupoPort,PublicKey,PrivateKey,GrupoId")] Integrador integrador)
        {
            if (id != integrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(integrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegradorExists(integrador.Id))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", integrador.GrupoId);
            return View(integrador);
        }

        // GET: Integradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Integradores == null)
            {
                return NotFound();
            }

            var integrador = await _context.Integradores
                .Include(i => i.Grupo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integrador == null)
            {
                return NotFound();
            }

            return View(integrador);
        }

        // POST: Integradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Integradores == null)
            {
                return Problem("Entity set 'GrupoContext.Integradores'  is null.");
            }
            var integrador = await _context.Integradores.FindAsync(id);
            if (integrador != null)
            {
                _context.Integradores.Remove(integrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegradorExists(int id)
        {
          return _context.Integradores.Any(e => e.Id == id);
        }
    }
}

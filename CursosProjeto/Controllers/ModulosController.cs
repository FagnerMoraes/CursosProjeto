using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoProjeto.Models;
using CursosProjeto.Data;
using Microsoft.AspNetCore.Authorization;

namespace CursosProjeto.Controllers
{
    [Authorize]
    public class ModulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modulos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.modulos.Include(m => m.curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Modulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.modulos
                .Include(m => m.curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // GET: Modulos/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.cursos, "Id", "Titulo");
            return View();
        }

        // POST: Modulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CursoId,DescricaoDoModulo,OrdemDeExibicao")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // GET: Modulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // POST: Modulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CursoId,DescricaoDoModulo,OrdemDeExibicao")] Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuloExists(modulo.Id))
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
            ViewData["CursoId"] = new SelectList(_context.cursos, "Id", "Titulo", modulo.CursoId);
            return View(modulo);
        }

        // GET: Modulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.modulos
                .Include(m => m.curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // POST: Modulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.modulos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.modulos'  is null.");
            }
            var modulo = await _context.modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.modulos.Remove(modulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuloExists(int id)
        {
          return (_context.modulos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

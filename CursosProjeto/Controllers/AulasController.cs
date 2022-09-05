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
    public class AulasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AulasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.aulas.Include(a => a.modulo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.aulas
                .Include(a => a.modulo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            ViewData["ModuloId"] = new SelectList(_context.modulos, "Id", "DescricaoDoModulo");
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuloId,DescricaoAula,UlrAula")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuloId"] = new SelectList(_context.modulos, "Id", "DescricaoDoModulo", aula.ModuloId);
            return View(aula);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            ViewData["ModuloId"] = new SelectList(_context.modulos, "Id", "DescricaoDoModulo", aula.ModuloId);
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModuloId,DescricaoAula,UlrAula")] Aula aula)
        {
            if (id != aula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id))
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
            ViewData["ModuloId"] = new SelectList(_context.modulos, "Id", "DescricaoDoModulo", aula.ModuloId);
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.aulas
                .Include(a => a.modulo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.aulas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.aulas'  is null.");
            }
            var aula = await _context.aulas.FindAsync(id);
            if (aula != null)
            {
                _context.aulas.Remove(aula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
          return (_context.aulas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

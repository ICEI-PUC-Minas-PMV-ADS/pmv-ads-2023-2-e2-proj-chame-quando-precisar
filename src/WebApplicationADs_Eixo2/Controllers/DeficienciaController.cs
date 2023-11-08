using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;

namespace WebApplicationADs_Eixo2.Controllers
{
    public class DeficienciaController : Controller
    {
        private readonly AppDbContext _context;

        public DeficienciaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Deficiencia
        public async Task<IActionResult> Index()
        {
              return _context.Deficiencia != null ? 
                          View(await _context.Deficiencia.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Deficiencia'  is null.");
        }

        // GET: Deficiencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deficiencia == null)
            {
                return NotFound();
            }

            var deficiencia = await _context.Deficiencia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deficiencia == null)
            {
                return NotFound();
            }

            return View(deficiencia);
        }

        // GET: Deficiencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deficiencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,DtInclusao,DtAlteracao")] Deficiencia deficiencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deficiencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deficiencia);
        }

        // GET: Deficiencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deficiencia == null)
            {
                return NotFound();
            }

            var deficiencia = await _context.Deficiencia.FindAsync(id);
            if (deficiencia == null)
            {
                return NotFound();
            }
            return View(deficiencia);
        }

        // POST: Deficiencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,DtInclusao,DtAlteracao")] Deficiencia deficiencia)
        {
            if (id != deficiencia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deficiencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeficienciaExists(deficiencia.ID))
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
            return View(deficiencia);
        }

        // GET: Deficiencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deficiencia == null)
            {
                return NotFound();
            }

            var deficiencia = await _context.Deficiencia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deficiencia == null)
            {
                return NotFound();
            }

            return View(deficiencia);
        }

        // POST: Deficiencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deficiencia == null)
            {
                return Problem("Entity set 'AppDbContext.Deficiencia'  is null.");
            }
            var deficiencia = await _context.Deficiencia.FindAsync(id);
            if (deficiencia != null)
            {
                _context.Deficiencia.Remove(deficiencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeficienciaExists(int id)
        {
          return (_context.Deficiencia?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

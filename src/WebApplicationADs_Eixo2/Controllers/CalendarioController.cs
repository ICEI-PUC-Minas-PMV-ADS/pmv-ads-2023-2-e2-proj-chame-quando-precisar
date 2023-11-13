using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;
using WebApplicationADs_Eixo2.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationADs_Eixo2.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly AppDbContext _context;

        public CalendarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Calendario
        public async Task<IActionResult> Index()
        {
              return _context.Calendarios != null ? 
                          View(await _context.Calendarios.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Calendarios'  is null.");
        }

        // GET: Calendario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // GET: Calendario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calendario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdUser,Ano,Mes,Dia,DiaSemana,HoraInicio,HoraFim,Descricao")] Calendario calendario)
        {
            calendario.DtAlteracao = DateTime.Now;
            calendario.DtInclusao = DateTime.Now;

            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            calendario.IdUser = CurrentUserId;

            if (_context.usuarios.Where(p => p.Id == CurrentUserId).Any())
            {
                if (ModelState.IsValid)
                {
                    _context.Add(calendario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(calendario);
            }
            else
            {
                ViewBag.ErrorMessage = "Erro de identificação de usuário. Favor contactar o Administrador";
                return View();
            }
        }

        // GET: Calendario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
                if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }
            return View(calendario);
        }

        // POST: Calendario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("ID,IdUser,Ano,Mes,Dia,DiaSemana,HoraInicio,HoraFim,Descricao,DtInclusao,DtAlteracao")] Calendario calendario)
        {
            calendario.DtAlteracao = DateTime.Now;

            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (CurrentUserId != calendario.IdUser)
            {
                return RedirectToAction("AcessoNegado", "usuarios");
            }
            if (id != calendario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarioExists(calendario.ID))
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
            return View(calendario);
        }

        // GET: Calendario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // POST: Calendario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendarios == null)
            {
                return Problem("Entity set 'AppDbContext.Calendarios'  is null.");
            }
            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario != null)
            {
                _context.Calendarios.Remove(calendario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioExists(int id)
        {
          return (_context.Calendarios?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

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
    public class NotificacoesController : Controller
    {
        private readonly AppDbContext _context;

        public NotificacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Notificacoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Notificacoes.Include(n => n.UsuarioDestinatario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Notificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacoes = await _context.Notificacoes
                .Include(n => n.UsuarioDestinatario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacoes == null)
            {
                return NotFound();
            }

            return View(notificacoes);
        }

        // GET: Notificacoes/Create
        public IActionResult Create()
        {
            ViewData["IdDestinatario"] = new SelectList(_context.usuarios, "Id", "Nome");
            return View();
        }

        // POST: Notificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDestinatario,DataEnvio,TextoMensagem,lido,DtInclusao,DtAlteracao")] Notificacoes notificacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDestinatario"] = new SelectList(_context.usuarios, "Id", "Email", notificacoes.IdDestinatario);
            return View(notificacoes);
        }

        // GET: Notificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacoes = await _context.Notificacoes.FindAsync(id);
            if (notificacoes == null)
            {
                return NotFound();
            }
            ViewData["IdDestinatario"] = new SelectList(_context.usuarios, "Id", "Email", notificacoes.IdDestinatario);
            return View(notificacoes);
        }

        // POST: Notificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDestinatario,DataEnvio,TextoMensagem,lido,DtInclusao,DtAlteracao")] Notificacoes notificacoes)
        {
            if (id != notificacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacoesExists(notificacoes.Id))
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
            ViewData["IdDestinatario"] = new SelectList(_context.usuarios, "Id", "Email", notificacoes.IdDestinatario);
            return View(notificacoes);
        }

        // GET: Notificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacoes = await _context.Notificacoes
                .Include(n => n.UsuarioDestinatario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacoes == null)
            {
                return NotFound();
            }

            return View(notificacoes);
        }

        // POST: Notificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notificacoes == null)
            {
                return Problem("Entity set 'AppDbContext.Notificacoes'  is null.");
            }
            var notificacoes = await _context.Notificacoes.FindAsync(id);
            if (notificacoes != null)
            {
                _context.Notificacoes.Remove(notificacoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacoesExists(int id)
        {
          return (_context.Notificacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

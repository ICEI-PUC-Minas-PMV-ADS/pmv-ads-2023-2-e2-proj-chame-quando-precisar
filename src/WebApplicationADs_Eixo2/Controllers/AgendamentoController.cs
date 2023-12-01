using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;

namespace WebApplicationADs_Eixo2.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Agendamento
        public async Task<IActionResult> Index()
        {

            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var appDbContext = _context.Calendarios.Where(c =>
            (c.IdUsuario == CurrentUserId || c.PedindoAjuda 
            ));

            List<Calendario> lista = new();
            await appDbContext.ForEachAsync(c =>
            {
                Agendamento AgendamentoExist = _context.Agendamentos.FirstOrDefault(a => a.IdCalendario == c.Id);


            if (AgendamentoExist == null)
            {
                lista.Add(c);
            }
            else if (AgendamentoExist.IdColaborador==CurrentUserId)
                {
                    lista.Add(c);
                }
            });
            
            return View(lista);
        }

        // GET: Agendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            Calendario calendario = await _context.Calendarios.FirstOrDefaultAsync(c => c.Id == id);
            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (calendario != null)
            {
                Agendamento agendamento = new();
                agendamento.IdCalendario = id;
                agendamento.IdColaborador = CurrentUserId;
                agendamento.Descricao = calendario.Descricao;
                agendamento.DtInclusao = DateTime.Now;
                agendamento.DtAlteracao = DateTime.Now;

                if (ModelState.IsValid)
                {
                    _context.Agendamentos.Add(agendamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();
        }

        // GET: Agendamento/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
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
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "Id", "Email", calendario.IdUsuario);
            return View(calendario);
        }

        // POST: Agendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,Titulo,Descricao,DtInicioEvento,HoraInicio,DtFimEvento,HoraFim,PedindoAjuda,DtInclusao,DtAlteracao")] Calendario calendario)
        {
            if (id != calendario.Id)
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
                    if (!CalendarioExists(calendario.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "Id", "Email", calendario.IdUsuario);
            return View(calendario);
        }*/

        // GET: Agendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendarios == null)
            {
                return Problem("Entity set 'AppDbContext.Calendarios'  is null.");
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioExists(int id)
        {
            return (_context.Calendarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

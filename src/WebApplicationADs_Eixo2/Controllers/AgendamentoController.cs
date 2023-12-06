using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;

namespace WebApplicationADs_Eixo2.Controllers
{
    [Authorize(Roles ="COL")]
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
            List<int> Ids = new();

            await appDbContext.ForEachAsync(c =>
            {
                Agendamento AgendamentoExist = _context.Agendamentos.FirstOrDefault(a => a.IdCalendario == c.Id);
                if (c.Id == AgendamentoExist?.IdCalendario)
                {
                    Ids.Add(c.Id);
                }

                if (AgendamentoExist == null)
                {
                    lista.Add(c);
                }
                else if (AgendamentoExist.IdColaborador == CurrentUserId)
                    {
                        lista.Add(c);
                    }
            });

            ViewBag.Ids = Ids;
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

            await _context.Agendamentos.ForEachAsync(c =>
            {
                if (c.IdCalendario == id ){
                    ViewBag.Aceito = true;
                }                
            });

            Agendamento AgendamentoExist = _context.Agendamentos.FirstOrDefault(a => a.IdCalendario == id);
            ViewBag.IdAgendamento = AgendamentoExist?.Id;
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
                agendamento.Calendario = calendario;
                agendamento.Colaborador = await _context.usuarios.FirstOrDefaultAsync(u => u.Id == CurrentUserId);

                if (ModelState.IsValid)
                {

                    _context.Agendamentos.Add(agendamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Calendario");
                }                    
            }
            return NotFound();
        }

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
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.IdCalendario == id);

            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        private bool CalendarioExists(int id)
        {
            return (_context.Calendarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }      
    }
}

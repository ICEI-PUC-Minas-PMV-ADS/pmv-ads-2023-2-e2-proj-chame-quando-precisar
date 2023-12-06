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
using WebApplicationADs_Eixo2.Models.ViewModels;
using System.Globalization;

namespace WebApplicationADs_Eixo2.Controllers
{
    [Authorize(Roles ="DEF,COL")]
    public class CalendarioController : Controller
    {
        private readonly AppDbContext _context;
        static Calendario CalendarioPersistence = new Calendario();
        public CalendarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Calendario
        public async Task<IActionResult> Index()
        {
            var viewModel = new CalendarioViewModel
            {
                Calendarios = await _context.Calendarios.ToListAsync(),
                NovoCalendario = new Calendario() 
            };

            return _context.Calendarios != null ?
                View(viewModel) :
                Problem("Entity set 'AppDbContext.Calendarios' is null.");
        }

        // GET: Calendario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendarios == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create(CalendarioViewModel viewModel)
        {
            var usuario = await _context.usuarios.FindAsync(viewModel.NovoCalendario.IdUsuario);
            viewModel.NovoCalendario.DtInclusao = DateTime.Now;
            viewModel.NovoCalendario.Usuario = usuario;


            if (ModelState.IsValid)
            {
                
                _context.Calendarios.Add(viewModel.NovoCalendario);
                await _context.SaveChangesAsync();

                viewModel.Calendarios = await _context.Calendarios
                         .Where(c => c.Usuario.Id == usuario.Id) 
                         .ToListAsync();

                // Limpar o objeto NovoCalendario para um novo registro
                viewModel.NovoCalendario = new Calendario(); 
            }
            return View("Index", viewModel);

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
            
            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (calendario.IdUsuario == CurrentUserId)
            {
                CalendarioPersistence = calendario;
                return View(calendario);
            }
            else
            {
                return RedirectToAction("AcessoNegado", "Usuarios");
            }
            
            
        }

        // POST: Calendario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Ano,Mes,Dia,DiaSemana,HoraInicio,HoraFim,Descricao,DtInclusao,DtAlteracao")] Calendario calendario)
        {
        //  Camada de persistência, pegar tais dados direto do banco gera erro de instância
            CalendarioPersistence.DtAlteracao = DateTime.Now;
            CalendarioPersistence.Descricao = calendario.Descricao;
            CalendarioPersistence.HoraFim = calendario.HoraFim;
            CalendarioPersistence.HoraInicio = calendario.HoraInicio;
            calendario = CalendarioPersistence;

            if (calendario.HoraInicio > calendario.HoraFim)
            {
                ViewBag.ErrorMessage = "O Horário Inicial do agendamento não pode ser maior que o Horário Final";
                return View();
            }

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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendario == null)
            {
                return NotFound();
            }

            int CurrentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (calendario.IdUsuario == CurrentUserId)
            {
                return View(calendario);
            }
            else
            {
                return RedirectToAction("AcessoNegado", "Usuarios");
            }
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
          return (_context.Calendarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult GetCalendarioData()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var eventos = _context.Calendarios
                .Where(c => c.IdUsuario == userId)
                .Select(c => new
                {
                    id = c.Id,
                    title = c.Titulo,
                    start = $"{c.DtInicioEvento.ToString("yyyy-MM-dd")}T{c.HoraInicio}"
                    
                })
                .ToList();

            if (User.IsInRole("COL")) {
                            
                var eventosAg =  _context.Agendamentos
                .Where(a => a.IdColaborador == userId)
                .Select(c => new
                {
                    id = c.Calendario.Id,
                    title = c.Calendario.Titulo,
                    start = $"{c.Calendario.DtInicioEvento.ToString("yyyy-MM-dd")}T{c.Calendario.HoraInicio}"

                })
                .ToList();

                eventos = eventos.Concat(eventosAg).ToList();                
            }

            return Json(eventos);
        }

    }


}

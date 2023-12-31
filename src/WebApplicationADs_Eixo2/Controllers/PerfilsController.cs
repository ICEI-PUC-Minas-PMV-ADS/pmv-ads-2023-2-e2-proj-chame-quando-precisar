﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;

namespace WebApplicationADs_Eixo2.Controllers
{
    public class PerfilsController : Controller
    {
        private readonly AppDbContext _context;

        public PerfilsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
              return _context.Perfils != null ? 
                          View(await _context.Perfils.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Perfils'  is null.");
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Administrador,Deficiente,Colaborador,Ativo,DtInclusao")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {

                perfil.DtInclusao = DateTime.Now;
                _context.Add(perfil);
                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Perfil Inserido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Verifique os dados Enviados.";
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Administrador,Deficiente,Colaborador,Ativo,DtInclusao,DtAlteracao")] Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    perfil.DtAlteracao = DateTime.Now;
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["MensagemSucesso"] = "Dados atualizados com sucesso!";
                return RedirectToAction(nameof(Edit));
            }
            TempData["MensagemErro"] = "Verifique os dados Enviados.";
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }
            TempData["MensagemSucesso"] = "Perfil  Removido com sucesso!";
            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfils == null)
            {
                return Problem("Entity set 'AppDbContext.Perfils'  is null.");
            }
            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil != null)
            {
                _context.Perfils.Remove(perfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
          return (_context.Perfils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

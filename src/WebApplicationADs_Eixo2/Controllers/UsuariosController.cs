using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationADs_Eixo2.Models;

namespace WebApplicationADs_Eixo2.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return _context.usuarios != null ?
                        View(await _context.usuarios.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewBag.Perfis = new SelectList(_context.Perfils.Where(p => !p.Administrador), "ID", "Descricao");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,SobreNome,Email,Login,Senha,IdPerfil")] Usuarios usuarios)
        {
            usuarios.Ativo = true;
            usuarios.DtInclusao = DateTime.Now;

            ViewBag.Perfis = new SelectList(_context.Perfils.Where(p => !p.Administrador), "ID", "Descricao");

            if (ModelState.IsValid)
            {
                //criptografar senha
                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                // Verificar se o email já existe no banco de dados
                if (_context.usuarios.Any(u => u.Email == usuarios.Email))
                {
                    ModelState.AddModelError("Email", "Este email já está em uso.");
                    return View(usuarios);
                }
                if (_context.usuarios.Any(u => u.Login == usuarios.Login))
                {
                    ModelState.AddModelError("Login", "Este Login Já se encontra cadastrado");
                    return View(usuarios);
                }

                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            ViewBag.Perfis = new SelectList(_context.Perfils.Where(p => !p.Administrador), "ID", "Descricao");

            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,SobreNome,Email,Login,Senha,IdPerfil,Ativo,DtInclusao,DtAlteracao")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }
            ViewBag.Perfis = new SelectList(_context.Perfils.Where(p => !p.Administrador), "ID", "Descricao");
            if (ModelState.IsValid)
            {
                try
                {
                    usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
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
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.usuarios'  is null.");
            }
            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios != null)
            {
                _context.usuarios.Remove(usuarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return (_context.usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuarios usuario)
        {

            List<Usuarios> usuarios = _context.usuarios.ToList();
            List<Usuarios> usuariosFiltrados = new List<Usuarios>();

            foreach (var u in usuarios)
            {
                if (u.Email == usuario.Email)
                {
                    usuariosFiltrados.Add(u);
                }
            }
            var userEmail =  usuariosFiltrados.FirstOrDefault();            

            if (userEmail != null)
            {

                
                bool isValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, userEmail.Senha);
                if (isValid==true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name , userEmail.Nome),
                         new Claim(ClaimTypes.NameIdentifier , userEmail.Id.ToString()),
                          new Claim(ClaimTypes.Role , userEmail.IdPerfil.ToString()),

                    };

                    var usuarioIdenty =  new ClaimsIdentity(claims,"login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdenty);

                    var Aut = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                        IsPersistent = true,

                    };

                    await HttpContext.SignInAsync(principal, Aut);
                    Redirect("/");
                }
                return RedirectToAction(nameof(Login));
            }
            ModelState.AddModelError(string.Empty, "Email/Login inválidos OU senha incorreta");
            return View(usuario);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index()
        {

            
            return _context.usuarios.Include(n => n.Perfil) != null ?

                        View(_context.usuarios.Include(n => n.Perfil)) :
                        Problem("Entity set 'AppDbContext.usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        [Authorize(Roles = "ADM")]
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
        [Authorize(Roles = "ADM")]
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
        [Authorize(Roles = "ADM")]
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
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            //var user = User.Identity;
            //if (User.IsInRole("ADM"))
            //{

            //}

            ViewBag.Perfis = new SelectList(_context.Perfils, "ID", "Descricao");



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
        [Authorize(Roles = "ADM")]
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
        [Authorize(Roles = "ADM")]
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
        [Authorize(Roles = "ADM")]
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

        [AllowAnonymous]
        public IActionResult CadastroUser()
        {
            ViewBag.Perfis = new SelectList(_context.Perfils.Where(p => !p.Administrador), "ID", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CadastroUser([Bind("Nome,SobreNome,Email,Login,Senha,IdPerfil")] Usuarios usuarios)
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

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios usuario)
        {          
            string role = "";
            var user = _context.usuarios.Include(u => u.Perfil).FirstOrDefault(obj => obj.Email == usuario.Email);
            if (user == null)
            {
                 user = _context.usuarios.Include(u => u.Perfil).FirstOrDefault(obj => obj.Login == usuario.Email);
            }
            if (user != null)
            {
                if (user.Perfil.Administrador)
                {
                    role = "ADM";
                }
                else if (user.Perfil.Colaborador)
                {
                    role = "COL";
                }
                else
                {
                    role = "DEF";
                }

                if (user.Ativo)
                {
                    bool isValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);
                    if (isValid == true)
                    {

                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name , user.Nome),
                         new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                          new Claim(ClaimTypes.Role , role),
                           new Claim("CodigoUsuario", user.Id.ToString()),

                    };

                        var usuarioIdenty = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdenty);

                        var Aut = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                            IsPersistent = true,

                        };

                        await HttpContext.SignInAsync(principal, Aut);
                        return Redirect("/");
                    }
                    ModelState.AddModelError(string.Empty, "Senha Incorreta!");
                    return View(usuario);
                }
            }          
            ModelState.AddModelError(string.Empty, "Usuário não Encontrado OU Inativo");
            return View(usuario);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }

        [AllowAnonymous]
        public IActionResult AcessoNegado()
        {
            return View();
        }

        [Authorize(Roles = "DEF,COL")]
        public async Task<IActionResult> perfilUsuario(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }          

            ViewBag.Perfis = new SelectList(_context.Perfils, "ID", "Descricao");

            var coduser = int.Parse(@User.FindFirst("CodigoUsuario")?.Value);
            if (id != coduser)
            {
                return NotFound();
            }
            var usuarios = _context.usuarios.Include(u => u.DadosUsuarios).FirstOrDefault(obj => obj.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }
        
        [HttpPost]
        [Authorize(Roles = "DEF,COL")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> perfilUsuario(int id, [Bind("Id,Nome,SobreNome,Email,Login,Senha,IdPerfil,DtAlteracao,DadosUsuarios")] Usuarios usuarios)
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
                    if (usuarios.DadosUsuarios != null)
                    {
                        usuarios.DadosUsuarios.Usuario = usuarios;
                        _context.Update(usuarios.DadosUsuarios);
                    }

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

    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocacaoWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LocacaoWeb.Controllers
{
    [Authorize]
    public class GerenteController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Gerente> _userManager;
        private readonly SignInManager<Gerente> _signInManager;

        public GerenteController(Context context, UserManager<Gerente> userManager, SignInManager<Gerente> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Gerente
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gerentes.ToListAsync());
        }

        // GET: Gerente/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenteView = await _context.Gerentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (gerenteView == null)
            {
                return NotFound();
            }

            return View(gerenteView);
        }

        // GET: Gerente/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("id,email,senha,confirmarSenha")] GerenteView gerenteView)
        {
            if (ModelState.IsValid)
            {
                Gerente gerente = new Gerente
                {
                    UserName = gerenteView.email,
                    Email = gerenteView.email
                };

                IdentityResult resultado = await _userManager.CreateAsync(gerente, gerenteView.senha);

                if (resultado.Succeeded)
                {
                    _context.Add(gerenteView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AdicionarErros(resultado);
            }
            return View(gerenteView);
        }

        [AllowAnonymous]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("email, senha")] GerenteView gerenteView) 
        {

            //if (ModelState.IsValid)
            //{
                var resultado = await _signInManager.PasswordSignInAsync(gerenteView.email, gerenteView.senha, false, false);

                string name = User.Identity.Name;

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Portal", "Home");
                }
                ModelState.AddModelError("", "Login ou senha inválidos!");
            //}
            //ModelState.AddModelError("", "Por favor, Preencha todos os campos!");
            return View(gerenteView);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }
        
        // GET: Gerente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenteView = await _context.Gerentes.FindAsync(id);
            if (gerenteView == null)
            {
                return NotFound();
            }
            return View(gerenteView);
        }

        // POST: Gerente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("id,email,senha")] GerenteView gerenteView)
        {
            if (id != gerenteView.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerenteView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenteViewExists(gerenteView.id))
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
            return View(gerenteView);
        }

        // GET: Gerente/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenteView = await _context.Gerentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (gerenteView == null)
            {
                return NotFound();
            }

            return View(gerenteView);
        }

        // POST: Gerente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerenteView = await _context.Gerentes.FindAsync(id);
            _context.Gerentes.Remove(gerenteView);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenteViewExists(int id)
        {
            return _context.Gerentes.Any(e => e.id == id);
        }
    }
}

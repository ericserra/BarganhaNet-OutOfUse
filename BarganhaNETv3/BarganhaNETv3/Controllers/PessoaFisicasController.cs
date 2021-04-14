using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarganhaNETv3.Data;
using BarganhaNETv3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using BarganhaNETv3.Services;
using System.IO;

namespace BarganhaNETv3.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PessoaFisicasController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnviroment)
        {
            _userManager = userManager;
            _context = context;
            _hostEnvironment = hostEnviroment;
        }

        // GET: PessoaFisicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaFisica.ToListAsync());
        }

        // GET: PessoaFisicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Create
        public IActionResult Create(PessoaFisica pessoaFisica)
        {
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaFisica pessoaFisica, Endereco endereco)
        {
            
            if (ModelState.IsValid)
            {
                if (!ValidCPF.IsCpf(pessoaFisica.Cpf))
                {
                    ViewBag.Cpf = "CPF Inválido";
                    return View(pessoaFisica);
                }
                ViewBag.CpfValido = null;
                var usuario = new IdentityUser { UserName = pessoaFisica.Email, Email = pessoaFisica.Email, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(usuario, pessoaFisica.Senha);
                pessoaFisica.Endereco = endereco;
                InserirImagem(pessoaFisica);
                if (result.Succeeded)
                {
                    _context.Add(pessoaFisica);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(pessoaFisica);
        }

        private async void InserirImagem(PessoaFisica pessoaFisica)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(pessoaFisica.ArquivoFoto.FileName);
            string extension = Path.GetExtension(pessoaFisica.ArquivoFoto.FileName);
            pessoaFisica.Foto = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            string path = Path.Combine(wwwRootPath + "/Imagem/", pessoaFisica.Foto);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await pessoaFisica.ArquivoFoto.CopyToAsync(fileStream);
            }
        }

        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Nome,Sobrenome,Id,Foto,StatusDaConta,Avaliacao")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.Id))
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
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            _context.PessoaFisica.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaFisicaExists(int id)
        {
            return _context.PessoaFisica.Any(e => e.Id == id);
        }
    }
}

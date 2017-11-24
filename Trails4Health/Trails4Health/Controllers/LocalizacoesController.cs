using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;

namespace Trails4Health.Controllers
{
    public class LocalizacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalizacoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Localizacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Localizacoes.Include(l => l.Etapa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Localizacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacoes
                .Include(l => l.Etapa)
                .SingleOrDefaultAsync(m => m.LocalizacaoId == id);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // GET: Localizacoes/Create
        public IActionResult Create()
        {
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "EtapaId");
            return View();
        }

        // POST: Localizacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizacaoId,Nome,EtapaId")] Localizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "EtapaId", localizacao.EtapaId);
            return View(localizacao);
        }

        // GET: Localizacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacoes.SingleOrDefaultAsync(m => m.LocalizacaoId == id);
            if (localizacao == null)
            {
                return NotFound();
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "EtapaId", localizacao.EtapaId);
            return View(localizacao);
        }

        // POST: Localizacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizacaoId,Nome,EtapaId")] Localizacao localizacao)
        {
            if (id != localizacao.LocalizacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizacaoExists(localizacao.LocalizacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "EtapaId", localizacao.EtapaId);
            return View(localizacao);
        }

        // GET: Localizacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacoes
                .Include(l => l.Etapa)
                .SingleOrDefaultAsync(m => m.LocalizacaoId == id);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // POST: Localizacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizacao = await _context.Localizacoes.SingleOrDefaultAsync(m => m.LocalizacaoId == id);
            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LocalizacaoExists(int id)
        {
            return _context.Localizacoes.Any(e => e.LocalizacaoId == id);
        }
    }
}

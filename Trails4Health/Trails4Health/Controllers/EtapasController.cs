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
    public class EtapasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtapasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Etapas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Etapas.Include(e => e.Dificuldade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Etapas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapas
                .Include(e => e.Dificuldade)
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }

            return View(etapa);
        }

        // GET: Etapas/Create
        public IActionResult Create()
        {
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId");
            return View();
        }

        // POST: Etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtapaId,DificuldadeId,Nome,Inicio,Fim,AltitudeMax,AltitudeMin")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId", etapa.DificuldadeId);
            return View(etapa);
        }

        // GET: Etapas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapas.SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId", etapa.DificuldadeId);
            return View(etapa);
        }

        // POST: Etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtapaId,DificuldadeId,Nome,Inicio,Fim,AltitudeMax,AltitudeMin")] Etapa etapa)
        {
            if (id != etapa.EtapaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapaExists(etapa.EtapaId))
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
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId", etapa.DificuldadeId);
            return View(etapa);
        }

        // GET: Etapas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapas
                .Include(e => e.Dificuldade)
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }

            return View(etapa);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etapa = await _context.Etapas.SingleOrDefaultAsync(m => m.EtapaId == id);
            _context.Etapas.Remove(etapa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EtapaExists(int id)
        {
            return _context.Etapas.Any(e => e.EtapaId == id);
        }
    }
}

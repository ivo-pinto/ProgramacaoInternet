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
    public class EtapasTrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtapasTrilhosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EtapasTrilhos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EtapasTrilhos.Include(e => e.Etapa).Include(e => e.Trilho);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EtapasTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapasTrilho = await _context.EtapasTrilhos
                .Include(e => e.Etapa)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapasTrilho == null)
            {
                return NotFound();
            }

            return View(etapasTrilho);
        }

        // GET: EtapasTrilhos/Create
        public IActionResult Create()
        {
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "Fim");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim");
            return View();
        }

        // POST: EtapasTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtapasTrilhoId,EtapaId,TrilhoId")] EtapasTrilho etapasTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapasTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "Fim", etapasTrilho.EtapaId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", etapasTrilho.TrilhoId);
            return View(etapasTrilho);
        }

        // GET: EtapasTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapasTrilho = await _context.EtapasTrilhos.SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapasTrilho == null)
            {
                return NotFound();
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "Fim", etapasTrilho.EtapaId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", etapasTrilho.TrilhoId);
            return View(etapasTrilho);
        }

        // POST: EtapasTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtapasTrilhoId,EtapaId,TrilhoId")] EtapasTrilho etapasTrilho)
        {
            if (id != etapasTrilho.EtapaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapasTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapasTrilhoExists(etapasTrilho.EtapaId))
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
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "Fim", etapasTrilho.EtapaId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", etapasTrilho.TrilhoId);
            return View(etapasTrilho);
        }

        // GET: EtapasTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapasTrilho = await _context.EtapasTrilhos
                .Include(e => e.Etapa)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapasTrilho == null)
            {
                return NotFound();
            }

            return View(etapasTrilho);
        }

        // POST: EtapasTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etapasTrilho = await _context.EtapasTrilhos.SingleOrDefaultAsync(m => m.EtapaId == id);
            _context.EtapasTrilhos.Remove(etapasTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EtapasTrilhoExists(int id)
        {
            return _context.EtapasTrilhos.Any(e => e.EtapaId == id);
        }
    }
}

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
    public class FotosTrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotosTrilhosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: FotosTrilhos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FotosTrilhos.Include(f => f.Foto).Include(f => f.Trilho);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FotosTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosTrilho = await _context.FotosTrilhos
                .Include(f => f.Foto)
                .Include(f => f.Trilho)
                .SingleOrDefaultAsync(m => m.FotoId == id);
            if (fotosTrilho == null)
            {
                return NotFound();
            }

            return View(fotosTrilho);
        }

        // GET: FotosTrilhos/Create
        public IActionResult Create()
        {
            ViewData["FotoId"] = new SelectList(_context.Fotos, "FotoId", "FotoId");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim");
            return View();
        }

        // POST: FotosTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotosTrilhoId,FotoId,TrilhoId")] FotosTrilho fotosTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotosTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FotoId"] = new SelectList(_context.Fotos, "FotoId", "FotoId", fotosTrilho.FotoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", fotosTrilho.TrilhoId);
            return View(fotosTrilho);
        }

        // GET: FotosTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosTrilho = await _context.FotosTrilhos.SingleOrDefaultAsync(m => m.FotoId == id);
            if (fotosTrilho == null)
            {
                return NotFound();
            }
            ViewData["FotoId"] = new SelectList(_context.Fotos, "FotoId", "FotoId", fotosTrilho.FotoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", fotosTrilho.TrilhoId);
            return View(fotosTrilho);
        }

        // POST: FotosTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotosTrilhoId,FotoId,TrilhoId")] FotosTrilho fotosTrilho)
        {
            if (id != fotosTrilho.FotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotosTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotosTrilhoExists(fotosTrilho.FotoId))
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
            ViewData["FotoId"] = new SelectList(_context.Fotos, "FotoId", "FotoId", fotosTrilho.FotoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", fotosTrilho.TrilhoId);
            return View(fotosTrilho);
        }

        // GET: FotosTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosTrilho = await _context.FotosTrilhos
                .Include(f => f.Foto)
                .Include(f => f.Trilho)
                .SingleOrDefaultAsync(m => m.FotoId == id);
            if (fotosTrilho == null)
            {
                return NotFound();
            }

            return View(fotosTrilho);
        }

        // POST: FotosTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotosTrilho = await _context.FotosTrilhos.SingleOrDefaultAsync(m => m.FotoId == id);
            _context.FotosTrilhos.Remove(fotosTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FotosTrilhoExists(int id)
        {
            return _context.FotosTrilhos.Any(e => e.FotoId == id);
        }
    }
}

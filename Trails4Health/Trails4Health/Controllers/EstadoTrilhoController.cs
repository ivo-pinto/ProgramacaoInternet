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
    public class EstadoTrilhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadoTrilhoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EstadoTrilho
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EstadosTrilhos.Include(e => e.Estado).Include(e => e.Trilho);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EstadoTrilho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilhos
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EstadoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }

        // GET: EstadoTrilho/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome");
            ViewData["TrihoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim");
            return View();
        }

        // POST: EstadoTrilho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoTrihoId,TrihoId,EstadoId,DataInicio,DataFim,Causa")] EstadoTrilho estadoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", estadoTrilho.EstadoId);
            ViewData["TrihoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", estadoTrilho.TrihoId);
            return View(estadoTrilho);
        }

        // GET: EstadoTrilho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilhos.SingleOrDefaultAsync(m => m.EstadoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", estadoTrilho.EstadoId);
            ViewData["TrihoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", estadoTrilho.TrihoId);
            return View(estadoTrilho);
        }

        // POST: EstadoTrilho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoTrihoId,TrihoId,EstadoId,DataInicio,DataFim,Causa")] EstadoTrilho estadoTrilho)
        {
            if (id != estadoTrilho.EstadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTrilhoExists(estadoTrilho.EstadoId))
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
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", estadoTrilho.EstadoId);
            ViewData["TrihoId"] = new SelectList(_context.Trilhos, "TrihoId", "Fim", estadoTrilho.TrihoId);
            return View(estadoTrilho);
        }

        // GET: EstadoTrilho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilhos
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EstadoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }

        // POST: EstadoTrilho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTrilho = await _context.EstadosTrilhos.SingleOrDefaultAsync(m => m.EstadoId == id);
            _context.EstadosTrilhos.Remove(estadoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EstadoTrilhoExists(int id)
        {
            return _context.EstadosTrilhos.Any(e => e.EstadoId == id);
        }
    }
}

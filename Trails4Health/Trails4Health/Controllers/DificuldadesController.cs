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
    public class DificuldadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DificuldadesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Dificuldades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dificuldades.ToListAsync());
        }

        // GET: Dificuldades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldades
                .SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }

            return View(dificuldade);
        }

        // GET: Dificuldades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dificuldades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DificuldadeId,Nome,Observacao,Valor")] Dificuldade dificuldade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dificuldade);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dificuldade);
        }

        // GET: Dificuldades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldades.SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }
            return View(dificuldade);
        }

        // POST: Dificuldades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DificuldadeId,Nome,Observacao,Valor")] Dificuldade dificuldade)
        {
            if (id != dificuldade.DificuldadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dificuldade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DificuldadeExists(dificuldade.DificuldadeId))
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
            return View(dificuldade);
        }

        // GET: Dificuldades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldades
                .SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }

            return View(dificuldade);
        }

        // POST: Dificuldades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dificuldade = await _context.Dificuldades.SingleOrDefaultAsync(m => m.DificuldadeId == id);
            _context.Dificuldades.Remove(dificuldade);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DificuldadeExists(int id)
        {
            return _context.Dificuldades.Any(e => e.DificuldadeId == id);
        }
    }
}

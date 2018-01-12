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
    public class EstacaoAnoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstacaoAnoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EstacaoAno
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstacoesAno.ToListAsync());
        }

        // GET: EstacaoAno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoAno = await _context.EstacoesAno
                .SingleOrDefaultAsync(m => m.EstacaoAnoId == id);
            if (estacaoAno == null)
            {
                return NotFound();
            }

            return View(estacaoAno);
        }

        // GET: EstacaoAno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstacaoAno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstacaoAnoId,Nome,Observacao")] EstacaoAno estacaoAno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacaoAno);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estacaoAno);
        }

        // GET: EstacaoAno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoAno = await _context.EstacoesAno.SingleOrDefaultAsync(m => m.EstacaoAnoId == id);
            if (estacaoAno == null)
            {
                return NotFound();
            }
            return View(estacaoAno);
        }

        // POST: EstacaoAno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstacaoAnoId,Nome,Observacao")] EstacaoAno estacaoAno)
        {
            if (id != estacaoAno.EstacaoAnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacaoAno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacaoAnoExists(estacaoAno.EstacaoAnoId))
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
            return View(estacaoAno);
        }

        // GET: EstacaoAno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoAno = await _context.EstacoesAno
                .SingleOrDefaultAsync(m => m.EstacaoAnoId == id);
            if (estacaoAno == null)
            {
                return NotFound();
            }

            return View(estacaoAno);
        }

        // POST: EstacaoAno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estacaoAno = await _context.EstacoesAno.SingleOrDefaultAsync(m => m.EstacaoAnoId == id);
            _context.EstacoesAno.Remove(estacaoAno);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EstacaoAnoExists(int id)
        {
            return _context.EstacoesAno.Any(e => e.EstacaoAnoId == id);
        }
    }
}

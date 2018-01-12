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
    public class TipoFotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoFotosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TipoFotos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposFotos.ToListAsync());
        }

        // GET: TipoFotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFoto = await _context.TiposFotos
                .SingleOrDefaultAsync(m => m.TipoFotoId == id);
            if (tipoFoto == null)
            {
                return NotFound();
            }

            return View(tipoFoto);
        }

        // GET: TipoFotos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoFotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoFotoId,Nome,Descricao")] TipoFoto tipoFoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoFoto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoFoto);
        }

        // GET: TipoFotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFoto = await _context.TiposFotos.SingleOrDefaultAsync(m => m.TipoFotoId == id);
            if (tipoFoto == null)
            {
                return NotFound();
            }
            return View(tipoFoto);
        }

        // POST: TipoFotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoFotoId,Nome,Descricao")] TipoFoto tipoFoto)
        {
            if (id != tipoFoto.TipoFotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoFoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoFotoExists(tipoFoto.TipoFotoId))
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
            return View(tipoFoto);
        }

        // GET: TipoFotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFoto = await _context.TiposFotos
                .SingleOrDefaultAsync(m => m.TipoFotoId == id);
            if (tipoFoto == null)
            {
                return NotFound();
            }

            return View(tipoFoto);
        }

        // POST: TipoFotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoFoto = await _context.TiposFotos.SingleOrDefaultAsync(m => m.TipoFotoId == id);
            _context.TiposFotos.Remove(tipoFoto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TipoFotoExists(int id)
        {
            return _context.TiposFotos.Any(e => e.TipoFotoId == id);
        }
    }
}

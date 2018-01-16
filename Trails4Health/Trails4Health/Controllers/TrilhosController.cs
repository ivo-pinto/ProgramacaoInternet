using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{
    public class TrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public int PageSize = 3;

        public TrilhosController(ApplicationDbContext context)
        {
            _context = context;    
        }


        public ViewResult Index(int page = 1)
        {
            return View(
                new TrilhosListViewModel
                {

                   Trilhos = _context.Trilhos
                        .Skip(PageSize * (page - 1))
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Trilhos.Count()
                    }
                }
            );
        }
        

        // GET: Trilhos
       // public async Task<IActionResult> Index()
       // {
        //    return View(await _context.Trilhos.ToListAsync());
      //  }

        // GET: Trilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .SingleOrDefaultAsync(m => m.TrihoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhos/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Trilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Inicio,Fim,Altitude Maxima,Altitude Minima,Descricao,Interesse Historico,Beleza Paisagistica,Grau Dificuldade,Duracao Media")] TrilhoViewModel trilho)
        {
            if (ModelState.IsValid)
            {
                var novoTrilho = new Trilho
                {
                    Nome = trilho.Nome,
                    Inicio = trilho.Inicio,
                    Fim = trilho.Fim,
                    AltitudeMax = trilho.AltitudeMax,
                    AltitudeMin = trilho.AltitudeMin,
                    Descricao = trilho.Descricao,
                    InteresseHistorico = trilho.InteresseHistorico,
                    BelezaPai = trilho.BelezaPai,
                    GrauDificuldade = trilho.GrauDificuldade,
                    DuracaoMedia = trilho.DuracaoMedia

                };
                _context.Add(novoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trilho);
        }

        // GET: Trilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrihoId == id);
            if (trilho == null)
            {
                return NotFound();
            }
            return View(trilho);
        }

        // POST: Trilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Inicio,Fim,Altitude Maxima,Altitude Minima,Descricao,Interesse Historico,Beleza Paisagistica,Grau Dificuldade,Duracao Media")] Trilho trilho)
        {
            if (id != trilho.TrihoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhoExists(trilho.TrihoId))
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
            return View(trilho);
        }

        // GET: Trilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
               .SingleOrDefaultAsync(m => m.TrihoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrihoId == id);
            _context.Trilhos.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrihoId == id);
        }
    }
}

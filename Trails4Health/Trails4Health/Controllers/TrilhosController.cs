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
                   
                }
            );
        }

        

        public IActionResult SelecionarComparacao()
        {
            // Colocar registos da dbo.Trilhos numa lista
            TrilhosListViewModel tlvm = new TrilhosListViewModel();
            var trilhos = _context.Trilhos;
            tlvm.Trilhos = trilhos.ToListAsync().Result;

            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoID", "Nome");
            ViewData["Nome"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View(tlvm);
        }

        public IActionResult CompararTrilho()
        {

            return View();
        }

        public async Task<IActionResult> CompararTrilho(int? id1, int? id2)
        {
            
            if ((id1 == null)|| (id2 == null))
            {
                return NotFound();
            }

            ////CompararTrilhoViewModels ctvm = new CompararTrilhoViewModels();
            //id1 = ctvm.Trilho1.TrilhoId;
            //id2 = ctvm.Trilho2.TrilhoId;
            var trilho1 = await _context.Trilhos
                .SingleOrDefaultAsync(m => m.TrilhoId == id1);
            var trilho2 = await _context.Trilhos
                .SingleOrDefaultAsync(m => m.TrilhoId == id1);


            TrilhoViewModel trilhovm = new TrilhoViewModel
            {
                Nome = trilho1.Nome,
                Inicio = trilho1.Inicio,
                Fim = trilho1.Fim,
                AltitudeMax = trilho1.AltitudeMax,
                AltitudeMin = trilho1.AltitudeMin,
                Descricao = trilho1.Descricao,
                InteresseHistorico = trilho1.InteresseHistorico,
                BelezaPai = trilho1.BelezaPai,
                GrauDificuldade = trilho1.GrauDificuldade,
                DuracaoMedia = trilho1.DuracaoMedia
            };

            return View(trilhovm);

            //TrilhoViewModel trilhovm1 = new TrilhoViewModel
            //{
            //    Nome = trilho2.Nome,
            //    Inicio = trilho2.Inicio,
            //    Fim = trilho2.Fim,
            //    AltitudeMax = trilho2.AltitudeMax,
            //    AltitudeMin = trilho2.AltitudeMin,
            //    Descricao = trilho2.Descricao,
            //    InteresseHistorico = trilho2.InteresseHistorico,
            //    BelezaPai = trilho2.BelezaPai,
            //    GrauDificuldade = trilho2.GrauDificuldade,
            //    DuracaoMedia = trilho2.DuracaoMedia
            //};


            //return View(trilhovm1);
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
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
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

            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
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
            if (id != trilho.TrilhoId)
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
                    if (!TrilhoExists(trilho.TrilhoId))
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
               .SingleOrDefaultAsync(m => m.TrilhoId == id);
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
            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.Trilhos.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrilhoId == id);
        }
    }
}

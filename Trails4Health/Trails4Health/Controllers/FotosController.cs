using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using System.IO;
using System.Web;
using Trails4Health.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Trails4Health.Controllers
{
    
    public class FotosController : Controller
    {
        private ApplicationDbContext _context;

        public int PageSize = 3;

        

        public FotosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        
     
                public ViewResult Index(int page = 1)
                {
                    var flvm = new FotoListViewModel();
                    var fotos = _context.Fotos
                         .Include(f => f.EstacaoAno).Include(f => f.Localizacao).Include(f => f.TipoFoto).Include(f => f.FotosTrilhos)
                         .Skip(PageSize * (page - 1))
                         .Take(PageSize);
                    var pagingInfo = new PagingInfo{
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = _context.Fotos.Count()
                            };
                    flvm.Fotos = fotos;
                    flvm.PagingInfo = pagingInfo;
                    return View(flvm);
                }


       

        // GET: Fotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .Include(f => f.EstacaoAno)
                .Include(f => f.Localizacao)
                .Include(f => f.TipoFoto)
                .SingleOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Fotos/Create
        public IActionResult Create()
        {
            ViewData["EstacaoAnoId"] = new SelectList(_context.EstacoesAno, "EstacaoAnoId", "Nome");
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacoes, "LocalizacaoId", "Nome");
            ViewData["TipoFotoId"] = new SelectList(_context.TiposFotos, "TipoFotoId", "Nome");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizacaoId,Visivel,Data,EstacaoAnoId,TipoFotoId,UploadFicheiro,TrilhoId,FotoId")] FotoViewModel foto)
        {
            if (ModelState.IsValid)
            {
                var imagem = new Foto {
                    FotoId = foto.FotoId,
                    LocalizacaoId = foto.LocalizacaoId,
                    Visivel = foto.Visivel,
                    Data = foto.Data,
                    EstacaoAnoId = foto.EstacaoAnoId,
                    TipoFotoId = foto.TipoFotoId
                };
                using (var memoryStream = new MemoryStream())
                {
                    await foto.UploadFicheiro.CopyToAsync(memoryStream);
                    imagem.Imagem = memoryStream.ToArray();
                }
                //_context.Add(foto);
                var FotoTrilho = new FotosTrilho { Foto = imagem, Trilho = _context.Trilhos.SingleOrDefault(x => x.TrilhoId == foto.TrilhoId) };
                _context.Add(imagem);
                _context.Add(FotoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EstacaoAnoId"] = new SelectList(_context.EstacoesAno, "EstacaoAnoId", "Nome", foto.EstacaoAnoId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacoes, "LocalizacaoId", "Nome", foto.LocalizacaoId);
            ViewData["TipoFotoId"] = new SelectList(_context.TiposFotos, "TipoFotoId", "Nome", foto.TipoFotoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "TrilhoId", foto.TrilhoId);
            return View(foto);
        }

        // GET: Fotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos.SingleOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }
            ViewData["EstacaoAnoId"] = new SelectList(_context.EstacoesAno, "EstacaoAnoId", "Nome", foto.EstacaoAnoId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacoes, "LocalizacaoId", "Nome", foto.LocalizacaoId);
            ViewData["TipoFotoId"] = new SelectList(_context.TiposFotos, "TipoFotoId", "Nome", foto.TipoFotoId);
            return View(foto);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotoId,LocalizacaoId,Visivel,Data,EstacaoAnoId,TipoFotoId,Imagem,ImageMimeType")] Foto foto)
        {
            if (id != foto.FotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoExists(foto.FotoId))
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
            ViewData["EstacaoAnoId"] = new SelectList(_context.EstacoesAno, "EstacaoAnoId", "Nome", foto.EstacaoAnoId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacoes, "LocalizacaoId", "Nome", foto.LocalizacaoId);
            ViewData["TipoFotoId"] = new SelectList(_context.TiposFotos, "TipoFotoId", "Nome", foto.TipoFotoId);
            return View(foto);
        }

        // GET: Fotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .Include(f => f.EstacaoAno)
                .Include(f => f.Localizacao)
                .Include(f => f.TipoFoto)
                .SingleOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foto = await _context.Fotos.SingleOrDefaultAsync(m => m.FotoId == id);
            _context.Fotos.Remove(foto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FotoExists(int id)
        {
            return _context.Fotos.Any(e => e.FotoId == id);
        }
    } 
}

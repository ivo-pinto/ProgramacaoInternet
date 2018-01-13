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


namespace Trails4Health.Controllers
{
    public class FotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        
        /*
        public ActionResult FileUpload(Foto foto)
        {
            if (foto != null)
            {
                byte[] image = foto.Imagem;
                string path = foto.ImageMimeType;
                Localizacao localizacao = foto.Localizacao;
                EstacaoAno estacaoAno = foto.EstacaoAno;
                TipoFoto tipoFoto = foto.TipoFoto;
                DateTime data = foto.Data;
                bool visivel = foto.Visivel;
                // file is uploaded

                System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("ConnectionStringTrails4Health");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Foto (ImageMimeType) VALUES ('TESTEEEEE')";
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
        }
        */
        // GET: Fotos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fotos.Include(f => f.EstacaoAno).Include(f => f.Localizacao).Include(f => f.TipoFoto);
            return View(await applicationDbContext.ToListAsync());
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
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotoId,LocalizacaoId,Visivel,Data,EstacaoAnoId,TipoFotoId,Imagem")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EstacaoAnoId"] = new SelectList(_context.EstacoesAno, "EstacaoAnoId", "Nome", foto.EstacaoAnoId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacoes, "LocalizacaoId", "Nome", foto.LocalizacaoId);
            ViewData["TipoFotoId"] = new SelectList(_context.TiposFotos, "TipoFotoId", "Nome", foto.TipoFotoId);
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
        public async Task<IActionResult> Edit(int id, [Bind("FotoId,LocalizacaoId,Visivel,Data,EstacaoAnoId,TipoFotoId,Imagem")] Foto foto)
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

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
    public class CompararTrilhoController
    {

        private readonly ApplicationDbContext _context;

        public CompararTrilhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trilhos/Details/5
        public async Task<IActionResult> CompararTrilho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho1 = await _context.Trilhos
                .SingleOrDefaultAsync(m => m.TrihoId == id);

            var trilho2 = await _context.Trilhos
               .SingleOrDefaultAsync(m => m.TrihoId == id1);

            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }



    }
}

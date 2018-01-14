using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class EFFotoRepository : IFotoRepository
    {
        private ApplicationDbContext dbContext;

        public EFFotoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Foto> Historics => dbContext.Fotos;
    }
}

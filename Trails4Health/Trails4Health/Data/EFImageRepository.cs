using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models { 

    /// <summary>
    /// corrigir tudo mal!!!!!!!!!!!!!!
    /// </summary>
    public class EFImageRepository
    {
        private ApplicationDbContext dbContext;

        public EFImageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Foto> Images => dbContext.Image;
    }
}

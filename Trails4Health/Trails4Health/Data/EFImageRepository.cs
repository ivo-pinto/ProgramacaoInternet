using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models
{
    public class EFImageRepository : IImageRepository
    {
        private ApplicationDbContext dbContext;

        public EFImageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Foto> Images => dbContext.Image;
    }
}

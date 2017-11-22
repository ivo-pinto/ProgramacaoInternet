using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

            if (!dbContext.Image.Any())
            {
                EnsureImagePopulated(dbContext);
            }
            dbContext.SaveChanges();
        }

        private static void EnsureImagePopulated(ApplicationDbContext dbContext)
        {
            dbContext.Image.AddRange(new Foto { IdFoto = 123 }, new Foto { IdFoto = 1234 });
        }
        //dbContext.SaveChanges();

    }
}

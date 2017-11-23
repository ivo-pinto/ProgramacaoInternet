using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            ApplicationDbContext context = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context.Trilhos.Any()) return;
            context.Trilhos.AddRange(
            new Trilho { Nome = "Serra", Inicio = "A", Fim ="B", InteresseHistorico = 1, BelezaPai= 1, AltitudeMax= 10, AltitudeMin= 5, Descricao="Este trilho é altamente", Visivel=true  },
            new Trilho { Nome = "Rio", Inicio = "B", Fim = "C", InteresseHistorico = 2, BelezaPai = 5, AltitudeMax = 1000, AltitudeMin = 950, Descricao = "Este trilho é muito dificil", Visivel = true },
            new Trilho { Nome = "Regada", Inicio = "A", Fim = "C", InteresseHistorico = 5, BelezaPai = 3, AltitudeMax = 10, AltitudeMin = 5, Descricao = "Este trilho é Histórico", Visivel = true }
            );

            ApplicationDbContext context1 = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context1.Fotos.Any()) return;
            context.Fotos.AddRange(
            new Foto {  },
            new Foto {  },
            new Foto {  }
            );

            context.SaveChanges();
        }
    }
}

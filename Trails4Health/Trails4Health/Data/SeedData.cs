using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

            if (!dbContext.Fotos.Any())
            {
                EnsureFotosPopulated(dbContext);
            }

            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
            }

            if (!dbContext.Dificuldades.Any())
            {
                EnsureDificuldadesPopulated(dbContext);
            }

            if (!dbContext.Localizacoes.Any())
            {
                EnsureLocalizacoesPopulated(dbContext);
            }

            if (!dbContext.Etapas.Any())
            {
                EnsureEtapasPopulated(dbContext);
            }

            dbContext.SaveChanges();
        }

        private static void EnsureFotosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Fotos.AddRange(
              //      new Foto { EstacaoAno = "Verao", Tipo = 1, Url = "~/doc/fotos", Localizacao = null },
                //    new Foto { EstacaoAno = "Inverno", Tipo = 2, Url = "~/doc/fotos", Localizacao = null },
                  //  new Foto { EstacaoAno = "Primavera", Tipo = 3, Url = "~/doc/fotos", Localizacao = null }
                  );
        }

        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Trilhos.AddRange(
                    new Trilho { Nome = "Serra", Inicio = "A", Fim = "B", InteresseHistorico = 1, BelezaPai = 1, AltitudeMax = 10, AltitudeMin = 5, Descricao = "Este trilho é altamente", Visivel = true },
                    new Trilho { Nome = "Rio", Inicio = "B", Fim = "C", InteresseHistorico = 2, BelezaPai = 5, AltitudeMax = 1000, AltitudeMin = 950, Descricao = "Este trilho é muito dificil", Visivel = true },
                    new Trilho { Nome = "Regada", Inicio = "A", Fim = "C", InteresseHistorico = 5, BelezaPai = 3, AltitudeMax = 10, AltitudeMin = 5, Descricao = "Este trilho é Histórico", Visivel = true }
                  );
        }

        private static void EnsureDificuldadesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Dificuldades.AddRange(
                        new Dificuldade { Nome = "Facil", Observacao = "", Valor = 1 },
                        new Dificuldade { Nome = "Medio", Observacao = "", Valor = 2 },
                        new Dificuldade { Nome = "Dificil", Observacao = "", Valor = 3 }
                   );
        }

        private static void EnsureLocalizacoesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Localizacoes.AddRange(
                        new Localizacao { Nome = "Guarda", Coordenadas = null },
                        new Localizacao { Nome = "Celorico", Coordenadas = null },
                        new Localizacao { Nome = "Serra", Coordenadas = null }
                   );
        }

        private static void EnsureEtapasPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Etapas.AddRange(
                        new Etapa { Nome = "Primeira", Inicio = "A", Fim = "B", Dificuldade = null, AltitudeMax = 10, AltitudeMin = 15 },
                        new Etapa { Nome = "Segunda", Inicio = "B", Fim = "C", Dificuldade = null, AltitudeMax = 1000, AltitudeMin = 900 },
                        new Etapa { Nome = "Terceira", Inicio = "C", Fim = "A", Dificuldade = null, AltitudeMax = 1050, AltitudeMin = 1500 }
                   );
        }


    }
}

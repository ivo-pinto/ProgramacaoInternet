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
            if (!dbContext.Estados.Any())
            {
                EnsureEstadosPopulated(dbContext);
            }
            if (!dbContext.EstadosTrilhos.Any())
            {
                EnsureEstadosTrilhosPopulated(dbContext);
            }
            if (!dbContext.EtapasTrilhos.Any())
            {
                EnsureEtapasTrilhosPopulated(dbContext);
            }
            if (!dbContext.FotosTrilhos.Any())
            {
                EnsureFotosTrilhosPopulated(dbContext);
            }
            if (!dbContext.TiposFotos.Any())
            {
                EnsureTiposFotosPopulated(dbContext);
            }

            dbContext.SaveChanges();
        }

        private static void EnsureEtapasTrilhosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.EtapasTrilhos.AddRange(
                    new EtapasTrilho { Etapa = null, Trilho = null},
                    new EtapasTrilho { Etapa = null, Trilho = null},
                    new EtapasTrilho { Etapa = null, Trilho = null}
                  );
        }

        private static void EnsureTiposFotosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.TiposFotos.AddRange(
                    new TipoFoto { Nome = "Historica", Descricao = "Foto de local Historico" },
                    new TipoFoto { Nome = "Fauna", Descricao = "Animais" },
                    new TipoFoto { Nome = "Flora", Descricao = "Natureza" }
                  );
        }

        private static void EnsureFotosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Fotos.AddRange(
                    new Foto { EstacaoAno = "Verao", Localizacao = null, Visivel = true, Data = DateTime.Parse("05-10-2017"), TipoFoto = null, Imagem = null },
                    new Foto { EstacaoAno = "Inverno", Localizacao = null, Visivel = true, Data = DateTime.Parse("05-10-2017"), TipoFoto = null, Imagem = null },
                    new Foto { EstacaoAno = "Primavera", Localizacao = null, Visivel = true, Data = DateTime.Parse("05-10-2017"), TipoFoto = null, Imagem = null }
                  );
        }

        private static void EnsureFotosTrilhosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.FotosTrilhos.AddRange(
                    new FotosTrilho { Foto = null, Trilho = null },
                    new FotosTrilho { Foto = null, Trilho = null },
                    new FotosTrilho { Foto = null, Trilho = null }
                  );
        }

        private static void EnsureEstadosTrilhosPopulated(ApplicationDbContext dbContext)
        {
            // Como passar trilho e estado???
            dbContext.EstadosTrilhos.AddRange(
                    new EstadoTrilho { Trilho = null, Estado = null, DataInicio = DateTime.Parse("10-12-2018"), DataFim = DateTime.Parse("20-12-2018"), Causa = "Obras"},
                    new EstadoTrilho { Trilho = null, Estado = null, DataInicio = DateTime.Parse("15-05-2018"), DataFim = DateTime.Parse("20-05-2018"), Causa = "Manutenção" },
                    new EstadoTrilho { Trilho = null, Estado = null, DataInicio = DateTime.Parse("10-12-2018"), DataFim = DateTime.Parse("20-12-2018"), Causa = null }
                  );
        }

        private static void EnsureEstadosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Estados.AddRange(
                    new Estado { Nome = "Aberto", Descricao = "o trilho esta aberto ao publico" },
                    new Estado { Nome = "Fechado", Descricao = "o trilho esta fechado ao publico" }
                  );
        }

        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Trilhos.AddRange(
                    new Trilho { Nome = "Serra", Inicio = "A", Fim = "B", InteresseHistorico = 1, BelezaPai = 1, AltitudeMax = 10, AltitudeMin = 5, GrauDificuldade = 2 , Descricao = "Este trilho é altamente", Visivel = true },
                    new Trilho { Nome = "Rio", Inicio = "B", Fim = "C", InteresseHistorico = 2, BelezaPai = 5, AltitudeMax = 1000, AltitudeMin = 950, GrauDificuldade = 3, Descricao = "Este trilho é muito dificil", Visivel = true },
                    new Trilho { Nome = "Regada", Inicio = "A", Fim = "C", InteresseHistorico = 5, BelezaPai = 3, AltitudeMax = 10, AltitudeMin = 5, GrauDificuldade = 1, Descricao = "Este trilho é Histórico", Visivel = false }
                  );
        }

        private static void EnsureDificuldadesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Dificuldades.AddRange(
                        new Dificuldade { Nome = "Facil", Observacao = "facil", Valor = 1 },
                        new Dificuldade { Nome = "Medio", Observacao = "medio", Valor = 3 },
                        new Dificuldade { Nome = "Dificil", Observacao = "dificil", Valor = 5 }
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

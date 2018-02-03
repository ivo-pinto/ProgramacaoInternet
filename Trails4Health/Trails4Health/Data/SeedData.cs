using System;
using System.Collections.Generic;
using System.IO;
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

            if (!dbContext.TiposFotos.Any())
            {
                EnsureTiposFotosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.EstacoesAno.Any())
            {
                EnsureEstacoesAnoPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Dificuldades.Any())
            {
                EnsureDificuldadesPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Localizacoes.Any())
            {
                EnsureLocalizacoesPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Estados.Any())
            {
                EnsureEstadosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Fotos.Any())
            {
                EnsureFotosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Etapas.Any())
            {
                EnsureEtapasPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.FotosTrilhos.Any())
            {
                EnsureFotosTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.EtapasTrilhos.Any())
            {
                EnsureEtapasTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.EstadosTrilhos.Any())
            {
                EnsureEstadosTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }


            dbContext.SaveChanges();
        }
        

        private static void EnsureEtapasTrilhosPopulated(ApplicationDbContext dbContext)
        {
            Etapa Etapa1 = dbContext.Etapas.SingleOrDefault(e => e.Nome == "Primeira");
            Etapa Etapa2 = dbContext.Etapas.SingleOrDefault(e => e.Nome == "Segunda");
            Trilho Trilho1 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Serra");
            Trilho Trilho2 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Rio");

            dbContext.EtapasTrilhos.AddRange(
                    new EtapasTrilho { Etapa = Etapa1, Trilho = Trilho1},
                    new EtapasTrilho { Etapa = Etapa2, Trilho = Trilho2}
                  );
        }

        private static void EnsureEstacoesAnoPopulated(ApplicationDbContext dbContext)
        {
            dbContext.EstacoesAno.AddRange(
                    new EstacaoAno { Nome = "Verão", Observacao = "Calor" },
                    new EstacaoAno { Nome = "Primavera", Observacao = "Alergias" },
                    new EstacaoAno { Nome = "Outono", Observacao = "Chuva" },
                    new EstacaoAno { Nome = "Inverno", Observacao = "Frio" }
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
            Localizacao Localizacao1 = dbContext.Localizacoes.SingleOrDefault(e => e.Nome == "Guarda");
            Localizacao Localizacao2 = dbContext.Localizacoes.SingleOrDefault(e => e.Nome == "Celorico");
            TipoFoto TipoFoto1 = dbContext.TiposFotos.SingleOrDefault(e => e.Nome == "Fauna");
            TipoFoto TipoFoto2 = dbContext.TiposFotos.SingleOrDefault(e => e.Nome == "Flora");
            EstacaoAno Verao = dbContext.EstacoesAno.SingleOrDefault(e => e.Nome == "Verão");
            EstacaoAno Inverno = dbContext.EstacoesAno.SingleOrDefault(e => e.Nome == "Inverno");
            EstacaoAno Outono = dbContext.EstacoesAno.SingleOrDefault(e => e.Nome == "Outono");
            EstacaoAno Primavera = dbContext.EstacoesAno.SingleOrDefault(e => e.Nome == "Primavera");
            /*var file1 = Directory.GetFiles("~/Images/Animais.jpg");
            var file2 = Directory.GetFiles("~/Images/Cao.jpg");
            var file3 = Directory.GetFiles("~/Images/Neve.jpg");*/


            dbContext.Fotos.AddRange(
                    new Foto { EstacaoAno = Verao, Localizacao = Localizacao1, Visivel = true, Data = DateTime.Parse("05-10-2017"), TipoFoto = TipoFoto1, Imagem = null },
                    new Foto { EstacaoAno = Inverno, Localizacao = Localizacao2, Visivel = true, Data = DateTime.Parse("05-10-2018"), TipoFoto = TipoFoto1, Imagem = null },
                    new Foto { EstacaoAno = Primavera, Localizacao = Localizacao1, Visivel = true, Data = DateTime.Parse("05-05-2017"), TipoFoto = TipoFoto2, Imagem = null }
                  );
        }

        private static void EnsureFotosTrilhosPopulated(ApplicationDbContext dbContext)
        {
            Foto Foto1 = dbContext.Fotos.SingleOrDefault(e => e.Data == DateTime.Parse("05-10-2017"));
            Foto Foto2 = dbContext.Fotos.SingleOrDefault(e => e.Data == DateTime.Parse("05-10-2018"));
            Trilho Trilho1 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Serra");
            Trilho Trilho2 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Rio");

            dbContext.FotosTrilhos.AddRange(
                    new FotosTrilho { Foto = Foto1, Trilho = Trilho1 },
                    new FotosTrilho { Foto = Foto2, Trilho = Trilho2 }
                  );
        }

        private static void EnsureEstadosTrilhosPopulated(ApplicationDbContext dbContext)
        {
            Estado Estado1 = dbContext.Estados.SingleOrDefault(e => e.Nome == "Aberto");
            Estado Estado2 = dbContext.Estados.SingleOrDefault(e => e.Nome == "Fechado");
            Trilho Trilho1 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Serra");
            Trilho Trilho2 = dbContext.Trilhos.SingleOrDefault(e => e.Nome == "Rio");
            dbContext.EstadosTrilhos.AddRange(
                    new EstadoTrilho { Trilho = Trilho1, Estado = Estado1, DataInicio = DateTime.Parse("10-12-2018"), DataFim = DateTime.Parse("20-12-2018"), Causa = null},
                    new EstadoTrilho { Trilho = Trilho2, Estado = Estado2, DataInicio = DateTime.Parse("15-05-2018"), DataFim = DateTime.Parse("20-05-2018"), Causa = "Manutenção" }
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
                    new Trilho { Nome = "Serra", Inicio = "PontoA", Fim = "PontoB", InteresseHistorico = 1, BelezaPai = 1, AltitudeMax = 10, AltitudeMin = 5, GrauDificuldade = 2 , Descricao = "Este trilho é altamente", Visivel = true },
                    new Trilho { Nome = "Rio", Inicio = "PontoB", Fim = "PontoC", InteresseHistorico = 2, BelezaPai = 5, AltitudeMax = 1000, AltitudeMin = 950, GrauDificuldade = 3, Descricao = "Este trilho é muito dificil", Visivel = true },
                    new Trilho { Nome = "Regada", Inicio = "PontoA", Fim = "PontoC", InteresseHistorico = 5, BelezaPai = 3, AltitudeMax = 10, AltitudeMin = 5, GrauDificuldade = 1, Descricao = "Este trilho é Histórico", Visivel = false }
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
                        new Localizacao { Nome = "Guarda", Coordenadas = "N 39.607550º / W 010.072533º " },
                        new Localizacao { Nome = "Celorico", Coordenadas = "N 3.607550º / W 099.072533º " },
                        new Localizacao { Nome = "Serra", Coordenadas = "N 50.607550º / W 009.072533º " }
                   );
        }

        private static void EnsureEtapasPopulated(ApplicationDbContext dbContext)
        {
            Dificuldade Dificuldade1 = dbContext.Dificuldades.SingleOrDefault(e => e.Nome == "Facil");
            Dificuldade Dificuldade2 = dbContext.Dificuldades.SingleOrDefault(e => e.Nome == "Medio");
            Dificuldade Dificuldade3 = dbContext.Dificuldades.SingleOrDefault(e => e.Nome == "Dificil");

            dbContext.Etapas.AddRange(
                        new Etapa { Nome = "Primeira", Inicio = "A", Fim = "B", Dificuldade = Dificuldade1, AltitudeMax = 10, AltitudeMin = 15 },
                        new Etapa { Nome = "Segunda", Inicio = "B", Fim = "C", Dificuldade = Dificuldade2, AltitudeMax = 1000, AltitudeMin = 900 },
                        new Etapa { Nome = "Terceira", Inicio = "C", Fim = "A", Dificuldade = Dificuldade3, AltitudeMax = 1050, AltitudeMin = 1500 }
                   );
        }


    }
}

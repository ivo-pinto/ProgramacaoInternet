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
            /*
            ApplicationDbContext context = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context.Trilhos.Any()) return;
            context.Trilhos.AddRange(
            new Trilho { Nome = "Serra", Inicio = "A", Fim ="B", InteresseHistorico = 1, BelezaPai= 1, AltitudeMax= 10, AltitudeMin= 5, Descricao="Este trilho é altamente", Visivel=true  },
            new Trilho { Nome = "Rio", Inicio = "B", Fim = "C", InteresseHistorico = 2, BelezaPai = 5, AltitudeMax = 1000, AltitudeMin = 950, Descricao = "Este trilho é muito dificil", Visivel = true },
            new Trilho { Nome = "Regada", Inicio = "A", Fim = "C", InteresseHistorico = 5, BelezaPai = 3, AltitudeMax = 10, AltitudeMin = 5, Descricao = "Este trilho é Histórico", Visivel = true }
            );

            ApplicationDbContext context2 = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context2.Dificuldades.Any()) return;
            context2.Dificuldades.AddRange(
            new Dificuldade { Nome="Facil", Observacao="", Valor=1 },
            new Dificuldade { Nome = "Medio", Observacao = "", Valor = 2 },
            new Dificuldade { Nome = "Dificil", Observacao = "", Valor = 3 }
            );

            ApplicationDbContext context3 = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context3.Localizacoes.Any()) return;
            context3.Localizacoes.AddRange(
            new Localizacao { Nome="Guarda", Coordenadas="45N-25S" },
            new Localizacao { Nome = "Celorico", Coordenadas="39N-10S" },
            new Localizacao { Nome = "Serra", Coordenadas="40N-20S" }
            );


            ApplicationDbContext context1 = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context1.Fotos.Any()) return;
            context.Fotos.AddRange(
            new Foto { EstacaoAno="Verao", Tipo=1, Url="~/doc/fotos", Localizacao=null },
            new Foto { EstacaoAno = "Inverno", Tipo = 2, Url = "~/doc/fotos", Localizacao=null },
            new Foto { EstacaoAno = "Primavera", Tipo = 3, Url = "~/doc/fotos", Localizacao=null }
            );

            ApplicationDbContext context5 = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context5.Etapas.Any()) return;
            context5.Etapas.AddRange(
            new Etapa { Nome="Primeira", Inicio="A", Fim="B", Dificuldade = null, AltitudeMax= 10, AltitudeMin= 15 },
            new Etapa { Nome = "Segunda", Inicio = "B", Fim = "C", Dificuldade = null, AltitudeMax = 1000, AltitudeMin = 900 },
            new Etapa { Nome = "Terceira", Inicio = "C", Fim = "A", Dificuldade = null, AltitudeMax = 1050, AltitudeMin = 1500 }
            );


            context.SaveChanges();
            */
        }
    }
}

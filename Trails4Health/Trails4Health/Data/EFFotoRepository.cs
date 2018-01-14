using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class EFFotoRepository : IFotoRepository
    {

        // (classe baseada em DbContext) - crio um ctx para aceder ás tabelas da BD
        private ApplicationDbContext dbContext;

        // preciso do construtor com contexto da BD para passar Lista Trilhos nos serviços (ver startup.cs)
        public EFFotoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // implement de ITrails4HealthRepository
        // vai buscar os Trilhos á tabela de Trilhos - tenho de criar um serviço no startup.cs
        // aqui aparecem os implement de IRepository (por cada IEnumerable<Mymodels> em IRepository)
        public IEnumerable<Foto> Fotos => dbContext.Fotos;
        public IEnumerable<EstacaoAno> EstacoesAno => dbContext.EstacoesAno;
        public IEnumerable<TipoFoto> TiposFotos => dbContext.TiposFotos;
        public IEnumerable<Localizacao> Localizacoes => dbContext.Localizacoes;

    }
}

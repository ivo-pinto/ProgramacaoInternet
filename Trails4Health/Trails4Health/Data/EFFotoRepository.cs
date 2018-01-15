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
        
        public IEnumerable<Foto> Fotos => dbContext.Fotos;
        public IEnumerable<EstacaoAno> EstacoesAno => dbContext.EstacoesAno;
        public IEnumerable<TipoFoto> TiposFotos => dbContext.TiposFotos;
        public IEnumerable<Localizacao> Localizacoes => dbContext.Localizacoes;

    }
}

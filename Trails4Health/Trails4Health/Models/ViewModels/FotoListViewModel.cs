using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class FotoListViewModel
    {
        public IEnumerable<Foto> Foto { get; set; }
        public IEnumerable<EstacaoAno> EstacaoAno { get; set; }
        public IEnumerable<TipoFoto> TipoFoto { get; set; }
        public IEnumerable<Localizacao> Localizacao { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

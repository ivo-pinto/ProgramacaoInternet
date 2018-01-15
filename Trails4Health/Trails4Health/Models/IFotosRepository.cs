using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    interface IFotosRepository
    {
        IEnumerable<Foto> Fotos { get; }
        IEnumerable<TipoFoto> TiposFotos { get; }
        IEnumerable<Localizacao> Localizacoes { get; }
        IEnumerable<EstacaoAno> EstacaoAno { get; }
    }
}

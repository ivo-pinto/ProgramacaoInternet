using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class IFotoRepository
    {
        IEnumerable<Foto> Fotos { get; }
        IEnumerable<EstacaoAno> EstacoesAno { get; }
        IEnumerable<TipoFoto> TiposFotos { get; }
        IEnumerable<Localizacao> Localizacoes { get; }
    }
}

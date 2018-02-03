using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public interface ITrails4HealthRepository
    {
        IEnumerable<Trilho> Trilhos { get; }
        IEnumerable<Dificuldade> Dificuldades { get; }
        IEnumerable<EstadoTrilho> EstadoTrilhos { get; }
        IEnumerable<Estado> Estados { get; }
        IEnumerable<TipoFoto> TiposFoto { get; }
        IEnumerable<Foto> Fotos { get; }
        IEnumerable<Localizacao> Localizacoes { get; }
        IEnumerable<Etapa> Etapas { get; }
        IEnumerable<EstacaoAno> EstacoesAno { get; }
    }
}

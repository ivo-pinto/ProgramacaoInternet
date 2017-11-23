using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }

        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Nome { get; set; }

        public string Coordenadas; //mudar para tipo GeoCoordinate

        public Etapa Etapa { get; set; } //(FK) id da tabela localizacao
        public int EtapaId { get; set; }

        public ICollection<Foto> Fotos { get; set; }

   
        
    }
}

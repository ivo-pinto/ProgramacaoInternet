using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Localizacao
    {
        public int LocalizacaoId;

        [StringLength(60, MinimumLength = 3)]
        public string Nome;

        public string Coordenadas; //mudar para tipo GeoCoordinate

        public ICollection<Foto> Fotos { get; set; }
    }
}

using GeoCoordinatePortable;
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

        [Required(ErrorMessage = "Please enter location name")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Nome { get; set; }

        public GeoCoordinate Coordenadas; //mudar para tipo GeoCoordinate ---NAO ESTA NA BD

        
        

        public ICollection<Foto> Fotos { get; set; }

   
        
    }
}

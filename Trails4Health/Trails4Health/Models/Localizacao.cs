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

        [RegularExpression(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$", ErrorMessage = "Coordenada Inválida! Utilize o formato 'Longitude, Latitude'")]
        public string Coordenadas; 


        public ICollection<Foto> Fotos { get; set; }

   
        
    }
}

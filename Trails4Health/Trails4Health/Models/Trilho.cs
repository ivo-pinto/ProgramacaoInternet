using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trilho
    {

        public int TrihoId { get; set; }

        [Required(ErrorMessage = "Please enter Trail Name")]
        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Please enter the beggining of the Trail")]
        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Inicio { get; set; }



        [Required(ErrorMessage = "Please enter the end of the Trail")]
        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Fim { get; set; }//nota:procurar variavel cordgps

        [Required(ErrorMessage = "Please enter Max Altitude")]
        public int AltitudeMax { get; set; }
        [Required(ErrorMessage = "Please enter Min Altitude")]
        public int AltitudeMin { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        [StringLength(maximumLength: 1000, MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Please rate the Historical Interest Value")]
        [Range(minimum: 1, maximum: 3)]
        public int InteresseHistorico { get; set; }

        [Required(ErrorMessage = "Please rate the Beauty of the landscape")]
        [Range(minimum: 1, maximum: 3)]
        public int BelezaPai { get; set; }

        [Required(ErrorMessage = "Please enter the state of the trail")]
        public bool Visivel { get; set; } = true;


        public ICollection<FotosTrilho> FotosTrilhos { get; set; }

        public ICollection<EtapasTrilho> EtapasTrilhos { get; set; }

        public ICollection<EstadoTrilho> EstadosTrilhos { get; set; }
    }

    
}

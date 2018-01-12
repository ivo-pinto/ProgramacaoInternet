using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Etapa
    {

        public int EtapaId { get; set; }

        public int DificuldadeId { get; set; }

        [Required(ErrorMessage = "Please enter a Dificulty")]
        public Dificuldade Dificuldade { get; set; }

        [Required(ErrorMessage = "Please enter Stage Name")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Please enter the beggining of the Stage")]
        [StringLength(100, MinimumLength = 3)]
        public string Inicio { get; set; }

        [Required(ErrorMessage = "Please enter the end of the Stage")]
        [StringLength(100, MinimumLength = 3)]
        public string Fim { get; set; }

        [Range(0, 2500, ErrorMessage = "Please enter a correct altitude number")]
        public int AltitudeMax { get; set; }

        [Range(0, 2500, ErrorMessage = "Please enter a correct altitude number")]
        public int AltitudeMin { get; set; }

        public ICollection<EtapasTrilho> EtapasTrilhos { get; set; }
    }
}
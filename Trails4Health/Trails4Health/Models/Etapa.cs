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
        public Dificuldade Dificuldade { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Inicio { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Fim { get; set; }


        public int AltitudeMax { get; set; }


        public int AltitudeMin { get; set; }


    }
}
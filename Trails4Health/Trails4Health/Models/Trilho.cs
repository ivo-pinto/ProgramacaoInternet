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

        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Inicio { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Fim { get; set; }//nota:procurar variavel cordgps

        public int AltitudeMax { get; set; }
        public int AltitudeMin { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        public string Descricao { get; set; }


        public int DificuldadeId { get; set; }

        public int InteresseHistorico { get; set; }

        public int BelezaPai { get; set; }

        public ICollection<FotosTrilho> FotosTrilhos { get; set; }
    }

    
}

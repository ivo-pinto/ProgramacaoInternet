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

        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Inicio { get; set; }

        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Fim { get; set; }//nota:procurar variavel cordgps

        public int AltitudeMax { get; set; }
        public int AltitudeMin { get; set; }

        [StringLength(maximumLength: 1000, MinimumLength = 5)]
        public string Descricao { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public int DificuldadeId { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public int InteresseHistorico { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public int BelezaPai { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public ICollection<FotosTrilho> FotosTrilhos { get; set; }
    }

    
}

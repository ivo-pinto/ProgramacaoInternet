using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Dificuldade
    {

        public int DificuldadeId { get; set; }

        [Required(ErrorMessage = "Please enter Dificulty name")]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }


        [StringLength(60, MinimumLength = 0)]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Please enter Dificulty Value")]
        [Range(minimum: 1, maximum: 3)]
        public int Valor { get; set; }

        public ICollection<Etapa> Etapas { get; set; }

    }
}

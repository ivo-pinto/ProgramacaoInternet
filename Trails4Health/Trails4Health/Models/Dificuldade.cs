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

        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Observacao { get; set; }


        public int Valor { get; set; }

        public ICollection<Etapa> Etapas { get; set; }

    }
}

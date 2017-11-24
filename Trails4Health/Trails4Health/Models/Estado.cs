using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Estado
    {

        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Please enter State name")]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }


        [StringLength(1000, MinimumLength = 0)]
        public string Descricao { get; set; }

        public ICollection<EstadoTrilho> EstadosTrilhos { get; set; }

    }
}
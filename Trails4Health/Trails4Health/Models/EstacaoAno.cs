using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EstacaoAno
    {
        public int EstacaoAnoId { get; set; }

        [Required(ErrorMessage = "Please enter Trail Name")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 0)]
        public string Observacao { get; set; }

        public ICollection<Foto> Fotos { get; set; }

    }
}

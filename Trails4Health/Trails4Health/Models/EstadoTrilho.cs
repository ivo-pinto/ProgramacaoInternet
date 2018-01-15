using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EstadoTrilho
    {
        public int EstadoTrihoId { get; set; }

        public int TrihoId { get; set; }
        [Required(ErrorMessage = "Please enter Trail")]
        public Trilho Trilho { get; set; }

        public int EstadoId { get; set; }
        [Required(ErrorMessage = "Please enter State")]
        public Estado Estado { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public String Causa { get; set; }
    }
}
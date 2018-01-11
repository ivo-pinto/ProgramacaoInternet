using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EtapasTrilho
    {

        public int EtapasTrilhoId { get; set; }
        public int EtapaId { get; set; }
        [Required(ErrorMessage = "insira uma etapa valida")]
        public Etapa Etapa { get; set; }
        public int TrilhoId { get; set; }
        [Required(ErrorMessage = "insira um trilho válido")]
        public Trilho Trilho { get; set; }


    }
}

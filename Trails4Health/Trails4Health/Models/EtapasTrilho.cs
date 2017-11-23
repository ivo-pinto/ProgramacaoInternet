using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EtapasTrilho
    {

        public int EtapasTrilhoId { get; set; }
        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }


    }
}

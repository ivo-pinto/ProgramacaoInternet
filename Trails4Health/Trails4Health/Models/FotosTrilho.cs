using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FotosTrilho
    {
        public int FotosTrilhoId { get; set; }

        public int FotoId { get; set; }

        public Foto Foto { get; set; }

        public int TrilhoId { get; set; } //mudar para tipo Trilho

        public Trilho Trilho { get; set; }



    }
}


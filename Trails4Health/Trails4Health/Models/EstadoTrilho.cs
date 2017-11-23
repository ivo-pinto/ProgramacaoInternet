﻿using System;
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
        public int EstadoId { get; set; }
        public Trilho Trilho { get; set; }
        public Estado Estado { get; set; }

        [RegularExpression(@"\d{4}(-\d{2})(-\d{2})", ErrorMessage = "Data Inválida! Utilize o formato AAAA-MM-DD")]
        public DateTime DataInicio { get; set; }

        [RegularExpression(@"\d{4}(-\d{2})(-\d{2})", ErrorMessage = "Data Inválida! Utilize o formato AAAA-MM-DD")]
        public DateTime DataFim { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public String Causa { get; set; }
    }
}
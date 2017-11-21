using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FotosTrilho
    {
        public string Id_Fotos_Trilho { get; set; }
        public string Id_Foto { get; set; }
        public string Id_Trilho { get; set; }
        [RegularExpression(@"\d{4}(-\d{2})", ErrorMessage = "Ano e Mes invalido, AAAA-MM")]
        public string AnoMes { get; set; }
    }
}
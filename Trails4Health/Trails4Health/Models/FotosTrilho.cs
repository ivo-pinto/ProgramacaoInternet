using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FotosTrilho
    {
        public string IdFotosTrilho { get; set; }
        public static List<Foto> ListaFotos = new List<Foto>();
        public string IdTrilho { get; set; } //mudar para tipo Trilho
        [RegularExpression(@"\d{4}(-\d{2})", ErrorMessage = "Ano e Mes invalido, AAAA-MM")]
        public string AnoMes { get; set; }


        public FotosTrilho(string IdFotosTrilho, List<Foto> listaFotos, string IdTrilho, string AnoMes)
        {
            this.IdFotosTrilho = IdFotosTrilho;
            ListaFotos = listaFotos;
            this.IdTrilho = IdTrilho;
            this.AnoMes = AnoMes;

        }

        public void ApagaFotoTrilho(Foto imagem)
        {

            ListaFotos.Remove(imagem);

        }

        public List<Foto> Consultar()
        {
            return ListaFotos;
        }

    }
}
}

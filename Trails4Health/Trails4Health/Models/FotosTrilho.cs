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
        public static List<Foto> ListaFotos = new List<Foto>();
        public string Id_Trilho { get; set; } //mudar para tipo Trilho
        [RegularExpression(@"\d{4}(-\d{2})", ErrorMessage = "Ano e Mes invalido, AAAA-MM")]
        public string Ano_Mes { get; set; }

        
        public FotosTrilho(string IdFotosTrilho, List<Foto> listaFotos, string IdTrilho, string AnoMes)
        {
            Id_Fotos_Trilho = IdFotosTrilho;
            ListaFotos = listaFotos;
            Id_Trilho = IdTrilho;
            Ano_Mes = AnoMes;

        }

        public void InsereFotoTrilho(Foto imagem, string IdTrilho, string AnoMes)
        {
            ListaFotos.Add(imagem);
            Id_Trilho = IdTrilho;
            Ano_Mes = AnoMes;

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
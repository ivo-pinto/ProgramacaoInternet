using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Foto
    {
        public int FotoId;
        [Required(ErrorMessage = "Please enter location")]
        public string Localizacao { get; set; } //(FK) id da tabela localizacao
        public DateTime DataHora { get; set; }
        public string EstacaoAno { get; set; }
        [Required(ErrorMessage = "Please enter image type")]
        public string Tipo { get; set; } //Fauna Flora Histórico
        [Required(ErrorMessage = "Please upload Image")]
        public string Url { get; set; } //caminho para a imagem



    }
}

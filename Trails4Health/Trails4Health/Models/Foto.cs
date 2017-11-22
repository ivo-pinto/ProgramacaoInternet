using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Foto
    {
        public int IdFoto;
        [Required(ErrorMessage = "Please enter location")]
        public string Localizacao { get; set; } //(FK) id da tabela localizacao
        public DateTime DataHora { get; set; }
        public string EstacaoAno { get; set; }
        [Required(ErrorMessage = "Please enter image type")]
        public string Tipo { get; set; } //Fauna Flora Histórico
        [Required(ErrorMessage = "Please upload Image")]
        public string Url { get; set; } //caminho para a imagem


        public void InsereFoto(int IdFoto, string Localizacao, DateTime DataHora, string EstacaoAno, string Tipo, bool Aprovada, string Url)
        {
            this.IdFoto = IdFoto;
            this.Localizacao = Localizacao;
            this.DataHora = DataHora;
            this.EstacaoAno = EstacaoAno;
            this.Tipo = Tipo;
            this.Url = Url;
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Foto
    {
        public string ImageID { get; set; }
        [Required(ErrorMessage = "Please enter location")]
        public string Localizacao { get; set; } //(FK) id da tabela localizacao
        public DateTime DataHora { get; set; }
        public string EstacaoAno { get; set; }
        [Required(ErrorMessage = "Please enter image type")]
        public string Tipo { get; set; } //Fauna Flora Histórico
        public bool Aprovada { get; set; } //Imagem aprovada por administrador
        [Required(ErrorMessage = "Please upload Image")]
        public string Url { get; set; } //caminho para a imagem


        public InsereFoto(string ImageID, string Localizacao, DateTime DataHora, string EstacaoAno, string Tipo, bool Aprovada, string Url)
        {
            this.ImageID = ImageID;
            this.Localizacao = Localizacao;
            this.DataHora = DataHora;
            this.EstacaoAno = EstacaoAno;
            this.Tipo = Tipo;
            this.Aprovada = Aprovada;
            this.Url = Url;
        }

        public void ApagaFoto(Foto foto)
        {

            Remove(foto);

        }

        public List<Foto> Consultar()
        {
            return ListaFotos;
        }



    }
}

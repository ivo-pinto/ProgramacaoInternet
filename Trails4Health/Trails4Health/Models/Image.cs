using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Image
    {
        public string ImageID { get; set; }
        public string Localizacao { get; set; } //(FK) id da tabela localizacao
        public DateTime DataHora { get; set; }
        public string Id_Utilizador { get; set; } //Utilizador que itroduziu foto
        public string EstacaoAno { get; set; }
        public string Tipo { get; set; } //Fauna Flora Histórico
        public bool Aprovada { get; set; } //Imagem aprovada por administrador
        public string Url { get; set; } //caminho para a imagem
    }
}

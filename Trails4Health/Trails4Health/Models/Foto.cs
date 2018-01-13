 using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Foto
    {
        public int FotoId { get; set; }

        public Localizacao Localizacao { get; set; } //(FK) id da tabela localizacao
        public int LocalizacaoId { get; set; }


        public bool Visivel { get; set; } = false;


        [RegularExpression(@"(\d{2})(-\d{2}-)\d{4}", ErrorMessage = "Data Inválida! Utilize o formato DD-MM-AAAA")]
        public DateTime Data { get; set; }

        public int EstacaoAnoId { get; set; }
        public EstacaoAno EstacaoAno { get; set; }

        public int TipoFotoId { get; set; }
        public TipoFoto TipoFoto { get; set; }

        
        public byte[] Imagem { get; set; }
        public string ImageMimeType { get; set; }

        public ICollection<FotosTrilho> FotosTrilhos { get; set; }

     
        

    }
}

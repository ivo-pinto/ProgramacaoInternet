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

        [Required(ErrorMessage = "Please enter location")]
        public Localizacao Localizacao { get; set; } //(FK) id da tabela localizacao
        public int LocalizacaoId { get; set; }

        [Required(ErrorMessage = "Please enter the date that the photo was taken")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Please enter the Seasson")]
        [StringLength(60, MinimumLength = 3)]
        public string EstacaoAno { get; set; }

        [Required(ErrorMessage = "Please enter image type")]
        [Range(minimum: 1, maximum: 3)]
        public int Tipo { get; set; } //Fauna Flora Histórico


        [Required(ErrorMessage = "Please upload Image")]
        public string Url { get; set; } //caminho para a imagem

        public ICollection<FotosTrilho> FotosTrilhos { get; set; }

    }
}

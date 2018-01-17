using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class FotoEditViewModel
    {
        public int FotoId { get; set; }
        public int LocalizacaoId { get; set; }
        public DateTime Data { get; set; }
        public int EstacaoAnoId { get; set; }
        public int TipoFotoId { get; set; }
        public bool Visivel { get; set; }
        public byte[] Imagem { get; set; }
    }
}
